SELECT * FROM "Categoria" C

INSERT INTO "Categoria" VALUES
(md5(random()::text || clock_timestamp()::text)::uuid, 'A��o'),
(md5(random()::text || clock_timestamp()::text)::uuid, 'Drama'),
(md5(random()::text || clock_timestamp()::text)::uuid, 'Terror'),
(md5(random()::text || clock_timestamp()::text)::uuid, 'Com�dia'),
(md5(random()::text || clock_timestamp()::text)::uuid, 'Romance'),
(md5(random()::text || clock_timestamp()::text)::uuid, 'Suspense'),
(md5(random()::text || clock_timestamp()::text)::uuid, 'Policial'),
(md5(random()::text || clock_timestamp()::text)::uuid, 'Fantasia'),
(md5(random()::text || clock_timestamp()::text)::uuid, 'Aventura'),
(md5(random()::text || clock_timestamp()::text)::uuid, 'Biografia'),
(md5(random()::text || clock_timestamp()::text)::uuid, 'Graphic Novel'),
(md5(random()::text || clock_timestamp()::text)::uuid, 'Fic��o Cient�fica'),
(md5(random()::text || clock_timestamp()::text)::uuid, 'Hist�ria em Quadrinhos')