use management;

show tables;

use management;

-- classificação atual de uma modalidade e torneio



SELECT 
    e.nome AS equipe,
    t.nome AS torneio,
    c.pontos,
    c.vitorias,
    c.empates,
    c.derrotas,
    c.gols_marcados,
    c.gols_sofridos,
    c.saldo_de_gols
FROM 
    Classificacao c
JOIN 
    Equipes e ON c.equipe_id = e.id
JOIN 
    Torneios t ON c.torneio_id = t.id
WHERE 
    c.torneio_id = 1 -- ID do torneio
ORDER BY 
    c.pontos DESC, c.saldo_de_gols DESC;
    
    -- melhores jogadores por número de gols marcados



SELECT 
    a.nome AS atleta,
    e.nome AS equipe,
    SUM(r.gols_pontos) AS total_gols
FROM 
    Resultados r
JOIN 
    Atletas a ON r.equipe_id = a.equipe_id
JOIN 
    Equipes e ON a.equipe_id = e.id
WHERE 
    r.vitoria = TRUE
GROUP BY 
    a.id
ORDER BY 
    total_gols DESC
LIMIT 10;

 -- Mostrar os 10 melhores jogadores
-- 3. Consulta para mostrar o resultado do primeiro jogo de um torneio



SELECT 
    p.data_partida,
    ea.nome AS equipe_a,
    eb.nome AS equipe_b,
    p.resultado_a,
    p.resultado_b,
    CASE
        WHEN p.empate = TRUE THEN 'Empate'
        ELSE (SELECT nome FROM Equipes WHERE id = p.vencedor_id)
    END AS vencedor
FROM 
    Partidas p
JOIN 
    Equipes ea ON p.equipe_a_id = ea.id
JOIN 
    Equipes eb ON p.equipe_b_id = eb.id
WHERE 
    p.modalidade_id = 1 -- ID da modalidade
ORDER BY 
    p.data_partida ASC
LIMIT 1; 


-- verificar a classificação de uma equipe em um torneio



SELECT 
    e.nome AS equipe,
    c.pontos,
    c.vitorias,
    c.empates,
    c.derrotas,
    c.gols_marcados,
    c.gols_sofridos,
    c.saldo_de_gols,
    c.ordem_classificacao
FROM 
    Classificacao c
JOIN 
    Equipes e ON c.equipe_id = e.id
WHERE 
    c.torneio_id = 1 -- ID do torneio
    AND c.equipe_id = 1; -- ID da equipe
    
-- verificar o tipo de torneio e modalidades incluídas


SELECT 
    t.nome AS torneio,
    t.tipo_fase AS tipo_de_torneio,
    m.nome AS modalidade,
    m.tipo AS tipo_modalidade
FROM 
    Torneios t
JOIN 
    Modalidades m ON m.torneio_id = t.id
ORDER BY 
    t.nome;
-- 6. Consulta para verificar as próximas partidas agendadas de uma equipe
-- Essa consulta retorna as partidas futuras de uma equipe específica:


SELECT 
    p.data_partida,
    ea.nome AS equipe_a,
    eb.nome AS equipe_b,
    p.local
FROM 
    Partidas p
JOIN 
    Equipes ea ON p.equipe_a_id = ea.id
JOIN 
    Equipes eb ON p.equipe_b_id = eb.id
WHERE 
    (p.equipe_a_id = 1 OR p.equipe_b_id = 1) -- ID da equipe
    AND p.data_partida > CURDATE() -- Data futura
ORDER BY 
    p.data_partida ASC;
    
-- 7. Consulta para exibir todas as fases de um torneio com status
-- Essa consulta lista as fases de um torneio, exibindo seu status atual:



SELECT 
    f.nome AS fase,
    f.status,
    f.data_inicio,
    f.data_fim
FROM 
    Fases f
JOIN 
    Modalidades m ON f.modalidade_id = m.id
WHERE 
    m.torneio_id = 1 -- ID do torneio
ORDER BY 
    f.ordem ASC;
    
-- 8. Consulta para verificar o melhor marcador de um torneio
-- Aqui você pode listar os melhores jogadores em termos de gols marcados em um torneio:


SELECT 
    a.nome AS atleta,
    SUM(r.gols_pontos) AS total_gols,
    t.nome AS torneio
FROM 
    Resultados r
JOIN 
    Atletas a ON r.equipe_id = a.equipe_id
JOIN 
    Equipes e ON a.equipe_id = e.id
JOIN 
    Torneios t ON e.modalidade_id = t.id
WHERE 
    t.id = 1 -- ID do torneio
GROUP BY 
    a.id
ORDER BY 
    total_gols DESC
LIMIT 5; 
