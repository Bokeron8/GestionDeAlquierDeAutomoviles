-- =============================================
-- Restricciones (Constraints) para GestionDeAlquilerDeAutomoviles
-- =============================================

-- 1. Tabla Marca
ALTER TABLE Marca ADD CONSTRAINT PK_Marca PRIMARY KEY (id_marca);
ALTER TABLE Marca ADD CONSTRAINT CK_Marca_Activo CHECK (activo IN (0, 1));
ALTER TABLE Marca ADD CONSTRAINT DF_Marca_Activo DEFAULT 1 FOR activo;

-- 2. Tabla Categoria
ALTER TABLE Categoria ADD CONSTRAINT PK_Categoria PRIMARY KEY (id_categoria);
ALTER TABLE Categoria ADD CONSTRAINT CK_Categoria_Activo CHECK (activo IN (0, 1));
ALTER TABLE Categoria ADD CONSTRAINT DF_Categoria_Activo DEFAULT 1 FOR activo;

-- 3. Tabla Estado
ALTER TABLE Estado ADD CONSTRAINT PK_Estado PRIMARY KEY (id_estado);
ALTER TABLE Estado ADD CONSTRAINT CK_Estado_Activo CHECK (activo IN (0, 1));
ALTER TABLE Estado ADD CONSTRAINT DF_Estado_Activo DEFAULT 1 FOR activo;

-- 4. Tabla Rol
ALTER TABLE Rol ADD CONSTRAINT PK_Rol PRIMARY KEY (id_rol);
ALTER TABLE Rol ADD CONSTRAINT CK_Rol_Activo CHECK (activo IN (0, 1));
ALTER TABLE Rol ADD CONSTRAINT DF_Rol_Activo DEFAULT 1 FOR activo;

-- 5. Tabla Modelo
ALTER TABLE Modelo ADD CONSTRAINT PK_Modelo PRIMARY KEY (id_modelo);
ALTER TABLE Modelo ADD CONSTRAINT FK_Modelo_Marca FOREIGN KEY (id_marca) REFERENCES Marca(id_marca);
ALTER TABLE Modelo ADD CONSTRAINT CK_Modelo_Activo CHECK (activo IN (0, 1));
ALTER TABLE Modelo ADD CONSTRAINT DF_Modelo_Activo DEFAULT 1 FOR activo;

-- 6. Tabla Empleado
ALTER TABLE Empleado ADD CONSTRAINT PK_Empleado PRIMARY KEY (id_empleado);
ALTER TABLE Empleado ADD CONSTRAINT UQ_Empleado_Usuario UNIQUE (usuario);
ALTER TABLE Empleado ADD CONSTRAINT UQ_Empleado_DNI UNIQUE (dni);
ALTER TABLE Empleado ADD CONSTRAINT UQ_Empleado_Correo UNIQUE (correo);
ALTER TABLE Empleado ADD CONSTRAINT FK_Empleado_Rol FOREIGN KEY (id_rol) REFERENCES Rol(id_rol);
ALTER TABLE Empleado ADD CONSTRAINT CK_Empleado_Activo CHECK (activo IN (0, 1));
ALTER TABLE Empleado ADD CONSTRAINT DF_Empleado_Activo DEFAULT 1 FOR activo;

-- 7. Tabla Cliente
ALTER TABLE Cliente ADD CONSTRAINT PK_Cliente PRIMARY KEY (id_cliente);
ALTER TABLE Cliente ADD CONSTRAINT UQ_Cliente_DNI UNIQUE (dni);
ALTER TABLE Cliente ADD CONSTRAINT UQ_Cliente_Correo UNIQUE (correo);
ALTER TABLE Cliente ADD CONSTRAINT CK_Cliente_Activo CHECK (activo IN (0, 1));
ALTER TABLE Cliente ADD CONSTRAINT DF_Cliente_Activo DEFAULT 1 FOR activo;

-- 8. Tabla Vehiculo
ALTER TABLE Vehiculo ADD CONSTRAINT PK_Vehiculo PRIMARY KEY (id_vehiculo);
ALTER TABLE Vehiculo ADD CONSTRAINT UQ_Vehiculo_Matricula UNIQUE (matricula);
ALTER TABLE Vehiculo ADD CONSTRAINT UQ_Vehiculo_Chasis UNIQUE (chasis);
ALTER TABLE Vehiculo ADD CONSTRAINT FK_Vehiculo_Modelo FOREIGN KEY (id_modelo) REFERENCES Modelo(id_modelo);
ALTER TABLE Vehiculo ADD CONSTRAINT FK_Vehiculo_Categoria FOREIGN KEY (id_categoria) REFERENCES Categoria(id_categoria);
ALTER TABLE Vehiculo ADD CONSTRAINT CK_Vehiculo_Activo CHECK (activo IN (0, 1));
ALTER TABLE Vehiculo ADD CONSTRAINT DF_Vehiculo_Activo DEFAULT 1 FOR activo;

-- 9. Tabla Reserva
ALTER TABLE Reserva ADD CONSTRAINT PK_Reserva PRIMARY KEY (id_reserva);
ALTER TABLE Reserva ADD CONSTRAINT FK_Reserva_Estado FOREIGN KEY (id_estado) REFERENCES Estado(id_estado);
ALTER TABLE Reserva ADD CONSTRAINT FK_Reserva_Empleado FOREIGN KEY (id_empleado) REFERENCES Empleado(id_empleado);
ALTER TABLE Reserva ADD CONSTRAINT FK_Reserva_Vehiculo FOREIGN KEY (id_vehiculo) REFERENCES Vehiculo(id_vehiculo);
ALTER TABLE Reserva ADD CONSTRAINT FK_Reserva_Cliente FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente);
ALTER TABLE Reserva ADD CONSTRAINT CK_Reserva_Activo CHECK (activo IN (0, 1));
ALTER TABLE Reserva ADD CONSTRAINT DF_Reserva_Activo DEFAULT 1 FOR activo;

-- 10. Tabla Alquiler
ALTER TABLE Alquiler ADD CONSTRAINT PK_Alquiler PRIMARY KEY (id_alquiler);
ALTER TABLE Alquiler ADD CONSTRAINT FK_Alquiler_Reserva FOREIGN KEY (id_reserva) REFERENCES Reserva(id_reserva);
ALTER TABLE Alquiler ADD CONSTRAINT CK_Alquiler_MontoMora CHECK (montoMora >= 0);
ALTER TABLE Alquiler ADD CONSTRAINT DF_Alquiler_MontoMora DEFAULT 0 FOR montoMora;
ALTER TABLE Alquiler ADD CONSTRAINT CK_Alquiler_Activo CHECK (activo IN (0, 1));
ALTER TABLE Alquiler ADD CONSTRAINT DF_Alquiler_Activo DEFAULT 1 FOR activo;

-- 11. Tabla Danio
ALTER TABLE Danio ADD CONSTRAINT PK_Danio PRIMARY KEY (id_danio);
ALTER TABLE Danio ADD CONSTRAINT FK_Danio_Alquiler FOREIGN KEY (id_alquiler) REFERENCES Alquiler(id_alquiler);
ALTER TABLE Danio ADD CONSTRAINT CK_Danio_Activo CHECK (activo IN (0, 1));
ALTER TABLE Danio ADD CONSTRAINT DF_Danio_Activo DEFAULT 1 FOR activo;
