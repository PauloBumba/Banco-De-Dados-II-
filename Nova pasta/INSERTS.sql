INSERT INTO TORNEIO (DESCRICAO, STATUS, DATA_INICIO, DATA_FIM)
VALUES ('Olimpíadas 2024', 'PLANEJADO', '2024-07-24', '2024-08-09');
INSERT INTO MODALIDADE (NOME, DESCRICAO, PONTO_POR_VITORIA, PONTO_POR_EMPATE, QUANTIADE_DE_JOGADORES_POR_EQUIPE, QUANTIADE_DE_JOGADORES_RESERVA, TIPO, TORNEIO_ID)
VALUES 
('Futebol Masculino', 'Competição de Futebol Masculino', 3, 1, 11, 7, 'MASCULINO', 1),
('Futebol Feminino', 'Competição de Futebol Feminino', 3, 1, 11, 7, 'FEMININO', 1);
INSERT INTO GRUPO (NOME, MODALIDADE_ID)
VALUES 
('Grupo A', 1), -- Futebol Masculino
('Grupo B', 1), -- Futebol Masculino
('Grupo C', 2), -- Futebol Feminino
('Grupo D', 2); -- Futebol Feminino
INSERT INTO EQUIPA (NOME, DESCRICAO, MODALIDADE_ID)
VALUES 
('Brasil', 'Seleção Brasileira de Futebol', 1), -- Futebol Masculino
('Argentina', 'Seleção Argentina de Futebol', 1), -- Futebol Masculino
('EUA', 'Seleção Feminina dos Estados Unidos', 2), -- Futebol Feminino
('Alemanha', 'Seleção Feminina da Alemanha', 2); -- Futebol Feminino
INSERT INTO GRUPO_POR_EQUIPA (GRUPO_ID, EQUIPA_ID)
VALUES 
(1, 1), -- Brasil no Grupo A (Masculino)
(1, 2), -- Argentina no Grupo A (Masculino)
(3, 3), -- EUA no Grupo C (Feminino)
(3, 4); -- Alemanha no Grupo C (Feminino)
INSERT INTO ATLETA (NOME, NASCIMENTO, PAIS, ESTADO, CIDADE, SEXO, EQUIPA_ID)
VALUES 
('Neymar Jr', '1992-02-05', 'Brasil', 'São Paulo', 'São Paulo', 'M', 1), 
('Lionel Messi', '1987-06-24', 'Argentina', 'Buenos Aires', 'Buenos Aires', 'M', 2),
('Megan Rapinoe', '1985-07-05', 'EUA', 'California', 'Redding', 'F', 3),
('Alexandra Popp', '1991-04-06', 'Alemanha', 'Hessen', 'Frankfurt', 'F', 4);
INSERT INTO FASE (NOME, ORDEM, MODALIDADE_ID, DATA_INICIO, DATA_FIM)
VALUES 
('Fase de Grupos', 1, 1, '2024-07-24', '2024-07-30'),
('Fase de Grupos', 1, 2, '2024-07-24', '2024-07-30');
INSERT INTO PARTIDA (FASE_ID, GRUPO_ID, EQUIPA1_ID, EQUIPA2_ID, DATA_HORA, RESULTADO)
VALUES 
(1, 1, 1, 2, '2024-07-24 15:00', '2-1'),
(1, 1, 2, 1, '2024-07-25 18:00', '0-0'),
(2, 3, 3, 4, '2024-07-24 12:00', '1-0'),
(2, 3, 4, 3, '2024-07-25 20:00', '2-2');
INSERT INTO CALENDARIO (PARTIDA_ID, DATA_HORA, DESCRICAO)
VALUES 
(1, '2024-07-24 15:00', 'Brasil vs Argentina - Fase de Grupos'),
(2, '2024-07-25 18:00', 'Argentina vs Brasil - Fase de Grupos'),
(3, '2024-07-24 12:00', 'EUA vs Alemanha - Fase de Grupos'),
(4, '2024-07-25 20:00', 'Alemanha vs EUA - Fase de Grupos');
INSERT INTO CLASSIFICACAO (MODALIDADE_ID, GRUPO_POR_EQUIPA_ID, PONTOS, VITORIAS, EMPATES, DERROTAS, GOLS_PRO, GOLS_CONTRA)
VALUES 
(1, 1, 3, 1, 0, 0, 2, 1), -- Brasil
(1, 2, 1, 0, 1, 0, 1, 1), -- Argentina
(2, 3, 3, 1, 0, 0, 2, 0), -- EUA
(2, 4, 1, 0, 1, 0, 2, 2); -- Alemanha
INSERT INTO ESTATISTICA (PARTIDA_ID, EQUIPA_ID, ATLETA_ID, GOLS, ASSISTENCIAS, CHUTES_AO_GOL, FALTAS_COMETIDAS, CARTOES_AMARELOS, CARTOES_VERMELHOS, POSSE_BOLA_PERCENTUAL, PASSES_COMPLETOS)
VALUES 
(1, 1, 1, 1, 1, 3, 2, 0, 0, 55.5, 30), 
(1, 2, 2, 0, 0, 2, 3, 1, 0, 44.5, 25),
(3, 3, 3, 1, 2, 4, 1, 0, 0, 60.0, 40), 
(3, 4, 4, 0, 1, 1, 4, 2, 0, 40.0, 20);
