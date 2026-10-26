-- ===============================================
-- Datos de prueba - GestionDeAlquilerDeAutomoviles
--
-- Ejecutar DESPUES de db_structure.sql y db_restricciones.sql.
-- Las tablas Estado, Rol y Empleado no se cargan acá: ya tienen datos.
-- Al final del archivo quedan bloques comentados para reconstruirlas.
--
-- Los ids son explícitos. Por eso el script abre IDENTITY_INSERT por
-- tabla y, después del COMMIT, vuelve a sembrar cada identidad con
-- DBCC CHECKIDENT para que la próxima alta de la aplicación no choque
-- contra la clave primaria.
--
-- Las columnas DATETIME (Reserva y Alquiler) llevan literales en formato
-- yyyymmdd hh:mm:ss, sin guiones. Con guiones el orden depende del idioma
-- de la sesión y un SQL Server en español lee el año como día: error 242.
-- Las columnas DATE (Cliente y Empleado) sí aceptan yyyy-mm-dd sin riesgo.
--
-- Si una corrida anterior falló, cerrá la pestaña y abrí una nueva antes
-- de re-ejecutar: IDENTITY_INSERT queda prendido en la sesión y la
-- corrida siguiente muere en el primer SET con el error 8107.
-- ===============================================
USE GestionDeAlquilerDeAutomoviles;
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;
SET DATEFORMAT ymd;
GO

BEGIN TRY
    BEGIN TRANSACTION;

    -- 1. Marcas (Hyundai dada de baja)
    SET IDENTITY_INSERT Marca ON;
    -- 10 marcas
    INSERT INTO Marca (id_marca, marca, activo) VALUES
    (1, 'Toyota', 1),
    (2, 'Ford', 1),
    (3, 'Chevrolet', 1),
    (4, 'Volkswagen', 1),
    (5, 'Renault', 1),
    (6, 'Peugeot', 1),
    (7, 'Fiat', 1),
    (8, 'Honda', 1),
    (9, 'Nissan', 1),
    (10, 'Hyundai', 0);
    SET IDENTITY_INSERT Marca OFF;

    -- 2. Categorías (Van dada de baja)
    SET IDENTITY_INSERT Categoria ON;
    -- 6 categorias
    INSERT INTO Categoria (id_categoria, nombre, descripcion, activo) VALUES
    (1, 'Económico', 'Vehículos de bajo consumo para uso urbano', 1),
    (2, 'Compacto', 'Hatchback de tamaño medio, cómodo en ciudad', 1),
    (3, 'Sedán', 'Cuatro puertas con baúl amplio para viajes largos', 1),
    (4, 'SUV', 'Tracción alta y mayor capacidad de carga', 1),
    (5, 'Pick-up', 'Cabina doble para trabajo y carga pesada', 1),
    (6, 'Van', 'Furgón de carga y transporte de pasajeros', 0);
    SET IDENTITY_INSERT Categoria OFF;

    -- 3. Modelos (FK: Marca) - Kangoo y Strada dados de baja
    SET IDENTITY_INSERT Modelo ON;
    -- 24 modelos
    INSERT INTO Modelo (id_modelo, modelo, id_marca, activo) VALUES
    (1, 'Corolla', 1, 1),
    (2, 'Etios', 1, 1),
    (3, 'Hilux', 1, 1),
    (4, 'Fiesta', 2, 1),
    (5, 'Focus', 2, 1),
    (6, 'Ranger', 2, 1),
    (7, 'Onix', 3, 1),
    (8, 'Cruze', 3, 1),
    (9, 'S10', 3, 1),
    (10, 'Gol', 4, 1),
    (11, 'Polo', 4, 1),
    (12, 'Amarok', 4, 1),
    (13, 'Sandero', 5, 1),
    (14, 'Logan', 5, 1),
    (15, 'Kangoo', 5, 0),
    (16, '208', 6, 1),
    (17, '308', 6, 1),
    (18, 'Partner', 6, 1),
    (19, 'Argo', 7, 1),
    (20, 'Cronos', 7, 1),
    (21, 'Strada', 7, 0),
    (22, 'Fit', 8, 1),
    (23, 'Civic', 8, 1),
    (24, 'Versa', 9, 1);
    SET IDENTITY_INSERT Modelo OFF;

    -- 4. Vehículos (FK: Modelo, Categoría) - 28, 29 y 30 dados de baja
    SET IDENTITY_INSERT Vehiculo ON;
    -- 30 vehiculos
    INSERT INTO Vehiculo (id_vehiculo, matricula, chasis, color, anio, activo, id_modelo, id_categoria) VALUES
    (1, 'HO137WW', '8AJ00010791900000', 'Blanco', 2022, 1, 1, 3),
    (2, 'OZ174BJ', '8AJ00021583800000', 'Gris', 2021, 1, 2, 1),
    (3, 'VK211GW', '8AJ00032375700000', 'Negro', 2023, 1, 3, 5),
    (4, 'CV248LJ', '8AJ00043167600000', 'Rojo', 2020, 1, 4, 2),
    (5, 'JG285QW', '8AJ00053959500000', 'Azul', 2022, 1, 5, 3),
    (6, 'QR322VJ', '8AJ00064751400000', 'Blanco', 2024, 1, 6, 5),
    (7, 'XC359AW', '8AJ00075543300000', 'Plata', 2023, 1, 7, 1),
    (8, 'EN396FJ', '8AJ00086335200000', 'Negro', 2022, 1, 8, 3),
    (9, 'LY433KW', '8AJ00097127100000', 'Gris', 2021, 1, 9, 5),
    (10, 'SJ470PJ', '8AJ00107919000000', 'Blanco', 2020, 1, 10, 1),
    (11, 'ZU507UW', '8AJ00118710900000', 'Rojo', 2023, 1, 11, 2),
    (12, 'GF544ZJ', '8AJ00129502800000', 'Azul', 2022, 1, 12, 5),
    (13, 'NQ581EW', '8AJ00130294700000', 'Gris', 2021, 1, 13, 1),
    (14, 'UB618JJ', '8AJ00141086600000', 'Blanco', 2024, 1, 14, 2),
    (15, 'BM655OW', '8AJ00151878500000', 'Amarillo', 2023, 1, 16, 2),
    (16, 'IX692TJ', '8AJ00162670400000', 'Negro', 2022, 1, 17, 3),
    (17, 'PI729YW', '8AJ00173462300000', 'Rojo', 2022, 1, 19, 1),
    (18, 'WT766DJ', '8AJ00184254200000', 'Gris', 2023, 1, 20, 3),
    (19, 'DE803IW', '8AJ00195046100000', 'Azul', 2020, 1, 22, 2),
    (20, 'KP840NJ', '8AJ00205838000000', 'Plata', 2019, 1, 23, 3),
    (21, 'RA877SW', '8AJ00216629900000', 'Blanco', 2023, 1, 24, 2),
    (22, 'YL914XJ', '8AJ00227421800000', 'Gris', 2024, 1, 1, 3),
    (23, 'FW951CW', '8AJ00238213700000', 'Negro', 2024, 1, 7, 1),
    (24, 'MH988HJ', '8AJ00249005600000', 'Blanco', 2022, 1, 3, 5),
    (25, 'TS125MW', '8AJ00259797500000', 'Azul', 2021, 1, 5, 3),
    (26, 'AD162RJ', '8AJ00260589400000', 'Rojo', 2022, 1, 11, 2),
    (27, 'HO199WW', '8AJ00271381300000', 'Plata', 2023, 1, 8, 3),
    (28, 'OZ236BJ', '8AJ00282173200000', 'Blanco', 2018, 0, 15, 6),
    (29, 'VK273GW', '8AJ00292965100000', 'Gris', 2017, 0, 18, 6),
    (30, 'CV310LJ', '8AJ00303757000000', 'Rojo', 2019, 0, 6, 5);
    SET IDENTITY_INSERT Vehiculo OFF;

    -- 5. Clientes - 19 y 20 dados de baja
    SET IDENTITY_INSERT Cliente ON;
    -- 20 clientes
    INSERT INTO Cliente (id_cliente, nombre, apellido, dni, fecha_nacimiento, direccion, telefono, correo, nroLicencia, vencimientoLicencia, provincia, activo) VALUES
    (1, 'Lucía', 'Fernández', '38124567', '1990-04-12', 'Junín 245', '3794123456', 'lucia.fernandez@hotmail.com', 'LC-100234', '2029-04-12', 'Corrientes', 1),
    (2, 'Martín', 'Gómez', '33456789', '1985-09-23', 'San Lorenzo 1204', '3794234567', 'martin.gomez@gmail.com', 'LC-100345', '2028-09-23', 'Chaco', 1),
    (3, 'Sofía', 'Rodríguez', '40234567', '1992-01-30', 'Rioja 890', '3794345678', 'sofia.rodriguez@hotmail.com', 'LC-100456', '2030-01-30', 'Corrientes', 1),
    (4, 'Federico', 'López', '29567890', '1978-11-05', 'Bolivia 345', '3794456789', 'federico.lopez@gmail.com', 'LC-100567', '2027-11-05', 'Misiones', 1),
    (5, 'Camila', 'Martínez', '35890123', '1988-06-18', 'Córdoba 1780', '3794567890', 'camila.martinez@hotmail.com', 'LC-100678', '2029-06-18', 'Corrientes', 1),
    (6, 'Nicolás', 'Sosa', '42345678', '1994-03-27', 'Mendoza 233', '3794678901', 'nicolas.sosa@gmail.com', 'LC-100789', '2028-03-27', 'Entre Ríos', 1),
    (7, 'Valentina', 'Torres', '39678901', '1991-12-09', 'Ayacucho 567', '3794789012', 'valentina.torres@hotmail.com', 'LC-100890', '2031-12-09', 'Corrientes', 1),
    (8, 'Gonzalo', 'Pereyra', '31456780', '1983-07-14', 'Salta 1450', '3794890123', 'gonzalo.pereyra@gmail.com', 'LC-100901', '2028-07-14', 'Santa Fe', 1),
    (9, 'Agustina', 'Romero', '41234598', '1993-05-02', 'Catamarca 78', '3794901234', 'agustina.romero@hotmail.com', 'LC-101012', '2029-05-02', 'Corrientes', 1),
    (10, 'Emiliano', 'Díaz', '28789012', '1976-02-21', '9 de Julio 2210', '3794012345', 'emiliano.diaz@gmail.com', 'LC-101123', '2027-02-21', 'Formosa', 1),
    (11, 'Julieta', 'Bianchi', '37901234', '1989-10-11', 'Moreno 190', '3794129876', 'julieta.bianchi@hotmail.com', 'LC-101234', '2030-10-11', 'Buenos Aires', 1),
    (12, 'Leandro', 'Acosta', '43678912', '1996-08-30', 'Chacabuco 640', '3794231987', 'leandro.acosta@gmail.com', 'LC-101345', '2028-08-30', 'Corrientes', 1),
    (13, 'Micaela', 'Benítez', '36789023', '1987-04-04', 'Tucumán 1122', '3794342098', 'micaela.benitez@hotmail.com', 'LC-101456', '2029-04-04', 'Chaco', 1),
    (14, 'Santiago', 'Herrera', '32456781', '1984-01-17', 'Irigoyen 905', '3794453109', 'santiago.herrera@gmail.com', 'LC-101567', '2027-01-17', 'Córdoba', 1),
    (15, 'Florencia', 'Medina', '41901235', '1995-06-06', 'Belgrano 430', '3794564210', 'florencia.medina@hotmail.com', 'LC-101678', '2030-06-06', 'Corrientes', 1),
    (16, 'Diego', 'Cardozo', '27901234', '1974-09-19', 'Avenida Armenia 3010', '3794675321', 'diego.cardozo@gmail.com', 'LC-101789', '2028-09-19', 'Misiones', 1),
    (17, 'Antonella', 'Silva', '44345671', '1998-03-08', 'Paso de los Andes 150', '3794786432', 'antonella.silva@hotmail.com', 'LC-101890', '2031-03-08', 'Corrientes', 1),
    (18, 'Ramiro', 'Quiroga', '30890124', '1981-12-25', 'Maipú 760', '3794897543', 'ramiro.quiroga@gmail.com', 'LC-101901', '2029-12-25', 'Santiago del Estero', 1),
    (19, 'Belén', 'Aguirre', '39234561', '1992-07-31', 'Santa Fe 2040', '3794908654', 'belen.aguirre@hotmail.com', 'LC-102012', '2027-07-31', 'Salta', 0),
    (20, 'Tomás', 'Ríos', '45123478', '1999-11-11', 'Entre Ríos 512', '3794019765', 'tomas.rios@gmail.com', 'LC-102123', '2028-11-11', 'Tucumán', 0);
    SET IDENTITY_INSERT Cliente OFF;

    -- 6. Reservas (FK: Estado, Empleado, Vehículo, Cliente)
    -- id_estado: 1 Pendiente, 2 Confirmada, 3 En Curso, 4 Finalizada, 5 Cancelada
    -- 9 Finalizada, 6 En Curso, 6 Confirmada, 6 Pendiente, 3 Cancelada (inactivas)
    SET IDENTITY_INSERT Reserva ON;
    -- 30 reservas
    INSERT INTO Reserva (id_reserva, precio_diario_pactado, fecha_solicitud, fecha_inicio_reserva, fecha_fin_reserva, activo, id_estado, id_empleado, id_vehiculo, id_cliente) VALUES
    (1, 40000.00, '20260821 10:00:00', '20260825 09:00:00', '20260830 09:00:00', 1, 4, 2, 1, 1),
    (2, 25000.00, '20260827 10:00:00', '20260901 09:00:00', '20260904 09:00:00', 1, 4, 2, 2, 2),
    (3, 62000.00, '20260902 10:00:00', '20260908 09:00:00', '20260915 09:00:00', 1, 4, 5, 3, 3),
    (4, 32000.00, '20260909 10:00:00', '20260916 09:00:00', '20260920 09:00:00', 1, 4, 2, 4, 4),
    (5, 40000.00, '20260919 10:00:00', '20260922 09:00:00', '20260928 09:00:00', 1, 4, 2, 5, 5),
    (6, 62000.00, '20260925 10:00:00', '20260929 09:00:00', '20261002 09:00:00', 1, 4, 1, 6, 6),
    (7, 25000.00, '20261002 10:00:00', '20261007 09:00:00', '20261012 09:00:00', 1, 4, 2, 7, 7),
    (8, 40000.00, '20261008 10:00:00', '20261014 09:00:00', '20261018 09:00:00', 1, 4, 5, 8, 8),
    (9, 62000.00, '20261013 10:00:00', '20261020 09:00:00', '20261022 09:00:00', 1, 4, 2, 9, 9),
    (10, 25000.00, '20261018 10:00:00', '20261021 09:00:00', '20261029 09:00:00', 1, 3, 2, 10, 10),
    (11, 32000.00, '20261018 10:00:00', '20261022 09:00:00', '20261028 09:00:00', 1, 3, 2, 11, 11),
    (12, 62000.00, '20261018 10:00:00', '20261023 09:00:00', '20261028 09:00:00', 1, 3, 5, 12, 12),
    (13, 25000.00, '20261018 10:00:00', '20261024 09:00:00', '20261031 09:00:00', 1, 3, 2, 13, 13),
    (14, 32000.00, '20261018 10:00:00', '20261025 09:00:00', '20261029 09:00:00', 1, 3, 2, 14, 14),
    (15, 32000.00, '20261022 10:00:00', '20261025 09:00:00', '20261028 09:00:00', 1, 3, 4, 15, 15),
    (16, 40000.00, '20261026 10:00:00', '20261030 09:00:00', '20261102 09:00:00', 1, 2, 2, 16, 16),
    (17, 25000.00, '20261027 10:00:00', '20261101 09:00:00', '20261106 09:00:00', 1, 2, 2, 17, 17),
    (18, 40000.00, '20261029 10:00:00', '20261104 09:00:00', '20261108 09:00:00', 1, 2, 5, 18, 2),
    (19, 32000.00, '20261101 10:00:00', '20261108 09:00:00', '20261115 09:00:00', 1, 2, 2, 19, 4),
    (20, 40000.00, '20261109 10:00:00', '20261112 09:00:00', '20261115 09:00:00', 1, 2, 2, 20, 6),
    (21, 32000.00, '20261112 10:00:00', '20261116 09:00:00', '20261122 09:00:00', 1, 2, 1, 21, 8),
    (22, 40000.00, '20261029 10:00:00', '20261103 09:00:00', '20261107 09:00:00', 1, 1, 2, 22, 11),
    (23, 25000.00, '20261101 10:00:00', '20261107 09:00:00', '20261112 09:00:00', 1, 1, 2, 23, 13),
    (24, 62000.00, '20261103 10:00:00', '20261110 09:00:00', '20261113 09:00:00', 1, 1, 5, 24, 15),
    (25, 40000.00, '20261111 10:00:00', '20261114 09:00:00', '20261120 09:00:00', 1, 1, 2, 25, 17),
    (26, 32000.00, '20261114 10:00:00', '20261118 09:00:00', '20261122 09:00:00', 1, 1, 2, 26, 5),
    (27, 40000.00, '20261117 10:00:00', '20261122 09:00:00', '20261124 09:00:00', 1, 1, 4, 27, 7),
    (28, 40000.00, '20261030 10:00:00', '20261105 09:00:00', '20261110 09:00:00', 0, 5, 2, 1, 3),
    (29, 25000.00, '20261102 10:00:00', '20261109 09:00:00', '20261112 09:00:00', 0, 5, 5, 2, 9),
    (30, 62000.00, '20261112 10:00:00', '20261115 09:00:00', '20261119 09:00:00', 0, 5, 2, 3, 12);
    SET IDENTITY_INSERT Reserva OFF;

    -- 7. Alquileres (FK: Reserva)
    -- Solo para reservas En Curso (sin devolucion) y Finalizada (con devolucion).
    -- Los alquileres 7 y 8 se devolvieron tarde: montoMora > 0.
    SET IDENTITY_INSERT Alquiler ON;
    -- 15 alquileres
    INSERT INTO Alquiler (id_alquiler, fechaEntregaReal, fechaEntregaDevolucion, combustibleSalida, combustibleEntrada, kilometrajeSalida, kilometrajeEntrada, montoMora, activo, id_reserva) VALUES
    (1, '20260825 09:00:00', '20260830 18:00:00', 100.00, 62.00, 42500.00, 43637.00, 0.00, 1, 1),
    (2, '20260901 09:00:00', '20260904 18:00:00', 100.00, 69.00, 68300.00, 69034.00, 0.00, 1, 2),
    (3, '20260908 09:00:00', '20260915 18:00:00', 100.00, 76.00, 31200.00, 32851.00, 0.00, 1, 3),
    (4, '20260916 09:00:00', '20260920 18:00:00', 100.00, 83.00, 77600.00, 78628.00, 0.00, 1, 4),
    (5, '20260922 09:00:00', '20260928 18:00:00', 100.00, 90.00, 48900.00, 50405.00, 0.00, 1, 5),
    (6, '20260929 09:00:00', '20261002 18:00:00', 100.00, 57.00, 12700.00, 13582.00, 0.00, 1, 6),
    (7, '20261007 09:00:00', '20261014 18:00:00', 100.00, 64.00, 21400.00, 22759.00, 50000.00, 1, 7),
    (8, '20261014 09:00:00', '20261022 18:00:00', 100.00, 71.00, 39800.00, 40976.00, 160000.00, 1, 8),
    (9, '20261020 09:00:00', '20261022 18:00:00', 100.00, 78.00, 71200.00, 71973.00, 0.00, 1, 9),
    (10, '20261021 09:00:00', NULL, 100.00, NULL, 84500.00, NULL, 0.00, 1, 10),
    (11, '20261022 09:00:00', NULL, 100.00, NULL, 18600.00, NULL, 0.00, 1, 11),
    (12, '20261023 09:00:00', NULL, 100.00, NULL, 44300.00, NULL, 0.00, 1, 12),
    (13, '20261024 09:00:00', NULL, 100.00, NULL, 63400.00, NULL, 0.00, 1, 13),
    (14, '20261025 09:00:00', NULL, 100.00, NULL, 9800.00, NULL, 0.00, 1, 14),
    (15, '20261025 09:00:00', NULL, 100.00, NULL, 23100.00, NULL, 0.00, 1, 15);
    SET IDENTITY_INSERT Alquiler OFF;

    -- 8. Danios (FK: Alquiler) - solo de alquileres ya devueltos
    SET IDENTITY_INSERT Danio ON;
    -- 8 danios, el ultimo dado de baja
    INSERT INTO Danio (id_danio, zona, descripcion, evidenciaFotografica, activo, id_alquiler) VALUES
    (1, 'Paragolpes delantero', 'Rayón profundo sobre el paragolpes delantero, lado derecho.', NULL, 1, 1),
    (2, 'Paragolpes trasero', 'Golpe con abolladura leve en la esquina trasera izquierda.', 'Recursos/danios/paragolpes-trasero.jpg', 1, 2),
    (3, 'Puerta delantera izquierda', 'Abolladura por apertura contra columna en estacionamiento.', 'Recursos/danios/puerta-delantera.jpg', 1, 3),
    (4, 'Espejo retrovisor derecho', 'Carcasa del espejo quebrada, funciona eléctricamente.', NULL, 1, 4),
    (5, 'Parabrisas', 'Marca de piedra de 2 mm, no compromete la visión.', 'Recursos/danios/parabrisas.jpg', 1, 5),
    (6, 'Capó', 'Desconchado de pintura de 3 cm en el borde frontal.', NULL, 1, 6),
    (7, 'Llanta delantera derecha', 'Raspado en la llanta por roce con cordón.', NULL, 1, 7),
    (8, 'Baúl', 'Mancha de líquido en la alfombra del baúl.', NULL, 0, 8);
    SET IDENTITY_INSERT Danio OFF;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    -- Devuelve el error como resultado, no como mensaje: así no se pierde
    -- al copiar. La linea apunta a la sentencia exacta que falló.
    SELECT ERROR_NUMBER()  AS numero,
           ERROR_LINE()    AS linea,
           ERROR_MESSAGE() AS mensaje;
END CATCH
GO

-- Resembrar la identidad de cada tabla para que la aplicación continúe
-- desde el último id cargado y no repita la clave primaria.
DBCC CHECKIDENT ('Marca', RESEED);
DBCC CHECKIDENT ('Categoria', RESEED);
DBCC CHECKIDENT ('Modelo', RESEED);
DBCC CHECKIDENT ('Vehiculo', RESEED);
DBCC CHECKIDENT ('Cliente', RESEED);
DBCC CHECKIDENT ('Reserva', RESEED);
DBCC CHECKIDENT ('Alquiler', RESEED);
DBCC CHECKIDENT ('Danio', RESEED);
GO

-- ===============================================
-- Verificación: 10, 6, 24, 30, 20, 30, 15, 8
-- ===============================================
SELECT 'Marca' AS tabla, COUNT(*) AS filas FROM Marca
UNION ALL SELECT 'Categoria', COUNT(*) FROM Categoria
UNION ALL SELECT 'Modelo', COUNT(*) FROM Modelo
UNION ALL SELECT 'Vehiculo', COUNT(*) FROM Vehiculo
UNION ALL SELECT 'Cliente', COUNT(*) FROM Cliente
UNION ALL SELECT 'Reserva', COUNT(*) FROM Reserva
UNION ALL SELECT 'Alquiler', COUNT(*) FROM Alquiler
UNION ALL SELECT 'Danio', COUNT(*) FROM Danio;
GO

-- ===============================================
-- Limpieza previa (descomentar si las tablas ya tienen filas de prueba)
-- Borra en orden inverso a las claves foráneas y reinicia las identidades.
-- ===============================================
/*
DELETE FROM Danio;
DELETE FROM Alquiler;
DELETE FROM Reserva;
DELETE FROM Vehiculo;
DELETE FROM Cliente;
DELETE FROM Modelo;
DELETE FROM Categoria;
DELETE FROM Marca;
GO
DBCC CHECKIDENT ('Danio', RESEED, 0);
DBCC CHECKIDENT ('Alquiler', RESEED, 0);
DBCC CHECKIDENT ('Reserva', RESEED, 0);
DBCC CHECKIDENT ('Vehiculo', RESEED, 0);
DBCC CHECKIDENT ('Cliente', RESEED, 0);
DBCC CHECKIDENT ('Modelo', RESEED, 0);
DBCC CHECKIDENT ('Categoria', RESEED, 0);
DBCC CHECKIDENT ('Marca', RESEED, 0);
GO
*/

-- ===============================================
-- Reconstrucción de Estado, Rol y Empleado (ya cargados)
-- Descomentar solo si se recrea la base desde cero.
-- ===============================================
/*
SET IDENTITY_INSERT Estado ON;
INSERT INTO Estado (id_estado, nombre, descripcion, activo) VALUES
(1, 'Pendiente', 'Reserva creada pero falta pago o confirmacion', 1),
(2, 'Confirmada', 'Reserva confirmada, vehiculo asegurado para el cliente', 1),
(3, 'En Curso', 'El cliente retiro el vehiculo y el alquiler esta activo', 1),
(4, 'Finalizada', 'Vehiculo devuelto, revisado y contrato cerrado', 1),
(5, 'Cancelada', 'Reserva anulada por el cliente o la empresa', 1);
SET IDENTITY_INSERT Estado OFF;
GO

SET IDENTITY_INSERT Rol ON;
INSERT INTO Rol (id_rol, rol, descripcion, activo) VALUES
(1, 'Administrador', 'Acceso total al sistema y configuraciones', 1),
(2, 'Atencion al Cliente', 'Gestion de reservas, entrega y recepcion de vehiculos', 1),
(3, 'Mecanico', 'Mantenimiento, revision de danios y control de flota', 1),
(4, 'Gerente', 'Reportes, control financiero y supervision general', 1);
SET IDENTITY_INSERT Rol OFF;
GO

SET IDENTITY_INSERT Empleado ON;
INSERT INTO Empleado (id_empleado, usuario, contrasenia, nombre, apellido, dni, fecha_nacimiento, direccion, telefono, correo, fecha_contratacion, activo, id_rol) VALUES
(1, 'gerente',  '123456', 'Gerente',  'Prueba', '45760639', '2026-09-07', 'espa',       '12354123213', 'franco@hotmail.com', '2026-09-07', 1, 4),
(2, 'operador', '123456', 'Operador', 'Prueba', '40123321', '2026-09-07', 'En su casa', '3794202020',  'prueba@hotmail.com', '2026-09-07', 1, 2),
(3, 'inactivo', '123456', 'Inactivo', 'Prueba', '1234',     '2000-06-21', 'sad',        '37942680123', 'asd@gnal.com',       '2026-09-13', 0, 1),
(4, 'mecanico', '123456', 'Mecanico', 'Prueba', '45760632', '2026-05-05', 'salta 1243', '34324',       'asd@hotmail.com',    '2026-09-02', 1, 3),
(5, 'admin',    '123456', 'Franco',   'Zambrano', '123456', '2026-06-02', 'Salta 1234', '37942680',    'correo@hotmail.com', '2026-09-03', 1, 1);
SET IDENTITY_INSERT Empleado OFF;
*/
