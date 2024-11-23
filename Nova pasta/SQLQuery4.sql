CREATE TRIGGER AtualizarClassificacaoApósGol
ON ESTATISTICA
AFTER INSERT, UPDATE
AS
BEGIN
    -- Declaração de variáveis
    DECLARE @EquipeID INT, @ModalidadeID INT, @GrupoID INT, @Gols INT;

    -- Obter dados da tabela INSERTED
    SELECT 
        @EquipeID = EQUIPA_ID, 
        @ModalidadeID = MODALIDADE_ID, 
        @Gols = GOLS,
        @GrupoID = GRUPO_ID
    FROM INSERTED;

    -- Atualizar GOLS_PRO, GOLS_CONTRA e SALDO_GOLS na tabela CLASSIFICACAO
    UPDATE C
    SET 
        C.GOLS_PRO = (
            SELECT ISNULL(SUM(GOLS), 0) 
            FROM ESTATISTICA 
            WHERE EQUIPA_ID = @EquipeID AND MODALIDADE_ID = @ModalidadeID
        ),
        C.GOLS_CONTRA = (
            SELECT ISNULL(SUM(GOLS_CONTRA), 0) 
            FROM PARTIDA 
            WHERE GRUPO_ID = @GrupoID
        ),
        C.SALDO_GOLS = C.GOLS_PRO - C.GOLS_CONTRA
    FROM CLASSIFICACAO C
    WHERE C.EQUIPA_ID = @EquipeID
      AND C.MODALIDADE_ID = @ModalidadeID;
END;
