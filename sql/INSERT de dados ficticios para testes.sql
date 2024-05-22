-- Use the loja database
USE loja;

-- Insert 100 Clientes with unique names, CPFs, CNPJs, e-mails, telefones, and Inscrições Estaduais
INSERT INTO Cliente (Nome, CPF_CNPJ, DataNascimento, Email, Telefone, TipoPessoa, InscricaoEstadual, Isento, Genero, Bloqueado, Senha)
VALUES
('Michael Jackson', '12345678909', '1958-08-29', 'michael.jackson@example.com', '11111111111', 'Fisica', '123456789010', FALSE, 'Masculino', FALSE, 'senha123'),
('Elvis Presley', '98765432100', '1935-01-08', 'elvis.presley@example.com', '22222222222', 'Fisica', '123456789020', FALSE, 'Masculino', FALSE, 'senha123'),
('Albert Einstein', '32165498700', '1879-03-14', 'albert.einstein@example.com', '33333333333', 'Fisica', '123456789030', FALSE, 'Masculino', FALSE, 'senha123'),
('The Beatles', '12345678000195', NULL, 'contact@thebeatles.com', '44444444444', 'Juridica', '123456789040', FALSE, NULL, FALSE, 'senha123'),
('Walt Disney', '74125896300', '1901-12-05', 'walt.disney@example.com', '55555555555', 'Fisica', '123456789050', FALSE, 'Masculino', FALSE, 'senha123'),
('Coca-Cola Company', '12345678000206', NULL, 'info@coca-cola.com', '66666666666', 'Juridica', '123456789060', FALSE, NULL, FALSE, 'senha123'),
('Marilyn Monroe', '15935725800', '1926-06-01', 'marilyn.monroe@example.com', '77777777777', 'Fisica', '123456789070', FALSE, 'Feminino', FALSE, 'senha123'),
('Apple Inc.', '12345678000317', NULL, 'info@apple.com', '88888888888', 'Juridica', '123456789080', FALSE, NULL, FALSE, 'senha123'),
('Albert Camus', '25814736900', '1913-11-07', 'albert.camus@example.com', '99999999999', 'Fisica', '123456789090', FALSE, 'Masculino', FALSE, 'senha123'),
('Microsoft Corporation', '12345678000428', NULL, 'contact@microsoft.com', '10101010101', 'Juridica', '123456789100', FALSE, NULL, FALSE, 'senha123'),
('Pablo Picasso', '36925814700', '1881-10-25', 'pablo.picasso@example.com', '11111111222', 'Fisica', '123456789110', FALSE, 'Masculino', FALSE, 'senha123'),
('IBM', '12345678000539', NULL, 'info@ibm.com', '22222222333', 'Juridica', '123456789120', FALSE, NULL, FALSE, 'senha123'),
('Jane Austen', '45612378900', '1775-12-16', 'jane.austen@example.com', '33333333444', 'Fisica', '123456789130', FALSE, 'Feminino', FALSE, 'senha123'),
('Amazon', '12345678000640', NULL, 'info@amazon.com', '44444444555', 'Juridica', '123456789140', FALSE, NULL, FALSE, 'senha123'),
('Leonardo da Vinci', '65432198700', '1452-04-15', 'leonardo.davinci@example.com', '55555555666', 'Fisica', '123456789150', FALSE, 'Masculino', FALSE, 'senha123'),
('Facebook', '12345678000751', NULL, 'contact@facebook.com', '66666666777', 'Juridica', '123456789160', FALSE, NULL, FALSE, 'senha123'),
('Marie Curie', '74185296301', '1867-11-07', 'marie.curie@example.com', '77777777888', 'Fisica', '123456789170', FALSE, 'Feminino', FALSE, 'senha123'),
('Google', '12345678000862', NULL, 'info@google.com', '88888888999', 'Juridica', '123456789180', FALSE, NULL, FALSE, 'senha123'),
('Charles Darwin', '85296374101', '1809-02-12', 'charles.darwin@example.com', '99999999000', 'Fisica', '123456789190', FALSE, 'Masculino', FALSE, 'senha123'),
('Tesla, Inc.', '12345678000973', NULL, 'info@tesla.com', '10101010111', 'Juridica', '123456789200', FALSE, NULL, FALSE, 'senha123'),
('Isaac Newton', '95175385201', '1643-01-04', 'isaac.newton@example.com', '11111111333', 'Fisica', '123456789210', FALSE, 'Masculino', FALSE, 'senha123'),
('General Electric', '12345678001084', NULL, 'contact@ge.com', '22222222444', 'Juridica', '123456789220', FALSE, NULL, FALSE, 'senha123'),
('Audrey Hepburn', '78945612301', '1929-05-04', 'audrey.hepburn@example.com', '33333333555', 'Fisica', '123456789230', FALSE, 'Feminino', FALSE, 'senha123'),
('Sony', '12345678001195', NULL, 'info@sony.com', '44444444666', 'Juridica', '123456789240', FALSE, NULL, FALSE, 'senha123'),
('Galileo Galilei', '35715925801', '1564-02-15', 'galileo.galilei@example.com', '55555555777', 'Fisica', '123456789250', FALSE, 'Masculino', FALSE, 'senha123'),
('Samsung', '12345678001206', NULL, 'info@samsung.com', '66666666888', 'Juridica', '123456789260', FALSE, NULL, FALSE, 'senha123'),
('Frida Kahlo', '15975348601', '1907-07-06', 'frida.kahlo@example.com', '77777777999', 'Fisica', '123456789270', FALSE, 'Feminino', FALSE, 'senha123'),
('Netflix', '12345678001317', NULL, 'contact@netflix.com', '88888888000', 'Juridica', '123456789280', FALSE, NULL, FALSE, 'senha123'),
('Vincent van Gogh', '65478932101', '1853-03-30', 'vincent.vangogh@example.com', '99999999111', 'Fisica', '123456789290', FALSE, 'Masculino', FALSE, 'senha123'),
('Intel', '12345678001428', NULL, 'info@intel.com', '10101010222', 'Juridica', '123456789300', FALSE, NULL, FALSE, 'senha123'),
('Amelia Earhart', '75395185201', '1897-07-24', 'amelia.earhart@example.com', '11111111444', 'Fisica', '123456789310', FALSE, 'Feminino', FALSE, 'senha123'),
('Hewlett-Packard', '12345678001539', NULL, 'contact@hp.com', '22222222555', 'Juridica', '123456789320', FALSE, NULL, FALSE, 'senha123'),
('William Shakespeare', '35795148601', '1564-04-23', 'william.shakespeare@example.com', '33333333666', 'Fisica', '123456789330', FALSE, 'Masculino', FALSE, 'senha123'),
('Dell', '12345678001640', NULL, 'info@dell.com', '44444444777', 'Juridica', '123456789340', FALSE, NULL, FALSE, 'senha123'),
('Joan of Arc', '25896314701', '1412-01-06', 'joan.arc@example.com', '55555555888', 'Fisica', '123456789350', FALSE, 'Feminino', FALSE, 'senha123'),
('PepsiCo', '12345678001751', NULL, 'info@pepsi.com', '66666666999', 'Juridica', '123456789360', FALSE, NULL, FALSE, 'senha123'),
('Florence Nightingale', '15975348602', '1820-05-12', 'florence.nightingale@example.com', '77777777000', 'Fisica', '123456789370', FALSE, 'Feminino', FALSE, 'senha123'),
('Procter & Gamble', '12345678001862', NULL, 'info@pg.com', '88888888111', 'Juridica', '123456789380', FALSE, NULL, FALSE, 'senha123'),
('Sigmund Freud', '65478932102', '1856-05-06', 'sigmund.freud@example.com', '99999999222', 'Fisica', '123456789390', FALSE, 'Masculino', FALSE, 'senha123'),
('Nestlé', '12345678001973', NULL, 'info@nestle.com', '10101010333', 'Juridica', '123456789400', FALSE, NULL, FALSE, 'senha123'),
('Emily Dickinson', '75395185202', '1830-12-10', 'emily.dickinson@example.com', '11111111555', 'Fisica', '123456789410', FALSE, 'Feminino', FALSE, 'senha123'),
('Unilever', '12345678002084', NULL, 'info@unilever.com', '22222222666', 'Juridica', '123456789420', FALSE, NULL, FALSE, 'senha123'),
('Alexander Graham Bell', '35795148602', '1847-03-03', 'alexander.bell@example.com', '33333333777', 'Fisica', '123456789430', FALSE, 'Masculino', FALSE, 'senha123'),
('Cisco Systems', '12345678002195', NULL, 'info@cisco.com', '44444444888', 'Juridica', '123456789440', FALSE, NULL, FALSE, 'senha123'),
('Hedy Lamarr', '25896314702', '1914-11-09', 'hedy.lamarr@example.com', '55555555999', 'Fisica', '123456789450', FALSE, 'Feminino', FALSE, 'senha123'),
('Pfizer', '12345678002206', NULL, 'info432@pfizer.com', '66666666000', 'Juridica', '123456789460', FALSE, NULL, FALSE, 'senha123'),
('Thomas Edison', '15975348603', '1847-02-11', 'thomas.edison@example.com', '77777777111', 'Fisica', '123456789470', FALSE, 'Masculino', FALSE, 'senha123'),
('GlaxoSmithKline', '12345678002317', NULL, 'info@gsk.com', '88888888222', 'Juridica', '123456789480', FALSE, NULL, FALSE, 'senha123'),
('Ada Lovelace', '65478932103', '1815-12-10', 'ada.lovelace@example.com', '99999999333', 'Fisica', '123456789490', FALSE, 'Feminino', FALSE, 'senha123'),
('Johnson & Johnson', '12345678002428', NULL, 'info@jnj.com', '10101010444', 'Juridica', '123456789500', FALSE, NULL, FALSE, 'senha123'),
('Nikola Tesla', '75395185203', '1856-07-10', 'nikola.tesla@example.com', '11111111666', 'Fisica', '123456789510', FALSE, 'Masculino', FALSE, 'senha123'),
('Volkswagen', '12345678002539', NULL, 'info@vw.com', '22222222777', 'Juridica', '123456789520', FALSE, NULL, FALSE, 'senha123'),
('Marie Curie', '35795148603', '1867-11-07', 'marie.curie231@example.com', '33333333888', 'Fisica', '123456789530', FALSE, 'Feminino', FALSE, 'senha123'),
('Sony', '12345678002640', NULL, 'info21321@sony.com', '44444444999', 'Juridica', '123456789540', FALSE, NULL, FALSE, 'senha123'),
('Albert Einstein', '25896314703', '1879-03-14', 'albert.einstein2@example.com', '55555556000', 'Fisica', '123456789550', FALSE, 'Masculino', FALSE, 'senha123'),
('Intel', '12345678002751', NULL, 'info243@intel.com', '66666666111', 'Juridica', '123456789560', FALSE, NULL, FALSE, 'senha123'),
('Galileo Galilei', '15975348604', '1564-02-15', 'galileo.galilei2@example.com', '77777777222', 'Fisica', '123456789570', FALSE, 'Masculino', FALSE, 'senha123'),
('Dell', '12345678002862', NULL, 'info275@dell.com', '88888888333', 'Juridica', '123456789580', FALSE, NULL, FALSE, 'senha123'),
('Joan of Arc', '65478932104', '1412-01-06', 'joan.arc2@example.com', '99999999444', 'Fisica', '123456789590', FALSE, 'Feminino', FALSE, 'senha123'),
('PepsiCo', '12345678002973', NULL, 'info2231@pepsi.com', '10101010555', 'Juridica', '123456789600', FALSE, NULL, FALSE, 'senha123'),
('Emily Dickinson', '75395185204', '1830-12-10', 'emily.dickinson2@example.com', '11111111777', 'Fisica', '123456789610', FALSE, 'Feminino', FALSE, 'senha123'),
('Unilever', '12345678003084', NULL, 'info28565@unilever.com', '22222222888', 'Juridica', '123456789620', FALSE, NULL, FALSE, 'senha123'),
('Alexander Graham Bell', '35795148604', '1847-03-03', 'alexander.bell2@example.com', '33333333999', 'Fisica', '123456789630', FALSE, 'Masculino', FALSE, 'senha123'),
('Cisco Systems', '12345678003195', NULL, 'info2@cisco.com', '44444444000', 'Juridica', '123456789640', FALSE, NULL, FALSE, 'senha123'),
('Hedy Lamarr', '25896314704', '1914-11-09', 'hedy.lamarr2@example.com', '55555556111', 'Fisica', '123456789650', FALSE, 'Feminino', FALSE, 'senha123'),
('Pfizer', '12345678003206', NULL, 'info276575@pfizer.com', '66666666222', 'Juridica', '123456789660', FALSE, NULL, FALSE, 'senha123'),
('Thomas Edison', '15975348605', '1847-02-11', 'thomas.edison2@example.com', '77777777333', 'Fisica', '123456789670', FALSE, 'Masculino', FALSE, 'senha123'),
('GlaxoSmithKline', '12345678003317', NULL, 'info2@gsk.com', '88888888444', 'Juridica', '123456789680', FALSE, NULL, FALSE, 'senha123'),
('Ada Lovelace', '65478932105', '1815-12-10', 'ada.lovelace2@example.com', '99999999555', 'Fisica', '123456789690', FALSE, 'Feminino', FALSE, 'senha123'),
('Johnson & Johnson', '12345678003428', NULL, 'info7562@jnj.com', '10101010666', 'Juridica', '123456789700', FALSE, NULL, FALSE, 'senha123'),
('Nikola Tesla', '75395185205', '1856-07-10', 'nikola.tesla2@example.com', '11111111888', 'Fisica', '123456789710', FALSE, 'Masculino', FALSE, 'senha123'),
('Volkswagen', '12345678003539', NULL, 'info2765765@vw.com', '22222222999', 'Juridica', '123456789720', FALSE, NULL, FALSE, 'senha123'),
('Marie Curie', '35795148605', '1867-11-07', 'marie.curie2@example.com', '33333333000', 'Fisica', '123456789730', FALSE, 'Feminino', FALSE, 'senha123'),
('Sony', '12345678003640', NULL, 'info296@sony.com', '44444444111', 'Juridica', '123456789740', FALSE, NULL, FALSE, 'senha123'),
('Albert Einstein', '25896314705', '1879-03-14', 'albert.einstein3@example.com', '55555556222', 'Fisica', '123456789750', FALSE, 'Masculino', FALSE, 'senha123'),
('Intel', '12345678003751', NULL, 'info3768@intel.com', '66666666333', 'Juridica', '123456789760', FALSE, NULL, FALSE, 'senha123'),
('Galileo Galilei', '15975348606', '1564-02-15', 'galileo.galilei3@example.com', '77777777444', 'Fisica', '123456789770', FALSE, 'Masculino', FALSE, 'senha123'),
('Dell', '12345678003862', NULL, 'info38768@dell.com', '88888888555', 'Juridica', '123456789780', FALSE, NULL, FALSE, 'senha123'),
('Joan of Arc', '65478932106', '1412-01-06', 'joan.arc8673@example.com', '99999999666', 'Fisica', '123456789790', FALSE, 'Feminino', FALSE, 'senha123'),
('PepsiCo', '12345678003973', NULL, 'info3867876@pepsi.com', '10101010777', 'Juridica', '123456789800', FALSE, NULL, FALSE, 'senha123'),
('Emily Dickinson', '75395185206', '1830-12-10', 'emily.dickinson38768@example.com', '11111111999', 'Fisica', '123456789810', FALSE, 'Feminino', FALSE, 'senha123'),
('Unilever', '12345678004084', NULL, 'info367876@unilever.com', '22222222000', 'Juridica', '123456789820', FALSE, NULL, FALSE, 'senha123');