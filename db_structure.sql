-- CREATE DATABASE GestionDeAlquilerDeAutomoviles;

-- 1. Tablas Catálogo / Independientes
CREATE TABLE Marca
(
  id_marca INT IDENTITY(1,1) NOT NULL,
  marca VARCHAR(50) NOT NULL,
  activo BIT NOT NULL DEFAULT 1,
  PRIMARY KEY (id_marca)
);

CREATE TABLE Categoria
(
  id_categoria INT IDENTITY(1,1) NOT NULL,
  nombre VARCHAR(50) NOT NULL,
  descripcion VARCHAR(255) NULL,
  activo BIT NOT NULL DEFAULT 1,
  PRIMARY KEY (id_categoria)
);

CREATE TABLE Estado
(
  id_estado INT IDENTITY(1,1) NOT NULL,
  nombre VARCHAR(50) NOT NULL,
  descripcion VARCHAR(255) NULL,
  activo BIT NOT NULL DEFAULT 1,
  PRIMARY KEY (id_estado)
);

CREATE TABLE Rol
(
  id_rol INT IDENTITY(1,1) NOT NULL,
  rol VARCHAR(50) NOT NULL,
  descripcion VARCHAR(255) NULL,
  activo BIT NOT NULL DEFAULT 1,
  PRIMARY KEY (id_rol)
);

-- 2. Tablas Dependientes de Nivel 1
CREATE TABLE Modelo
(
  id_modelo INT IDENTITY(1,1) NOT NULL,
  modelo VARCHAR(50) NOT NULL,
  id_marca INT NOT NULL,
  activo BIT NOT NULL DEFAULT 1,
  PRIMARY KEY (id_modelo),
  FOREIGN KEY (id_marca) REFERENCES Marca(id_marca)
);

CREATE TABLE Empleado
(
  id_empleado INT IDENTITY(1,1) NOT NULL,
  usuario VARCHAR(50) UNIQUE NOT NULL,
  contrasenia VARCHAR(255) NOT NULL,
  nombre VARCHAR(50) NOT NULL,
  apellido VARCHAR(50) NOT NULL,
  dni VARCHAR(20) UNIQUE NOT NULL,
  fecha_nacimiento DATE NOT NULL,
  direccion VARCHAR(150) NULL,
  telefono VARCHAR(20) NULL,
  correo VARCHAR(100) UNIQUE NULL,
  fecha_contratacion DATE NOT NULL,
  activo BIT NOT NULL DEFAULT 1,
  id_rol INT NOT NULL,
  PRIMARY KEY (id_empleado),
  FOREIGN KEY (id_rol) REFERENCES Rol(id_rol)
);

CREATE TABLE Cliente
(
  id_cliente INT IDENTITY(1,1) NOT NULL,
  nombre VARCHAR(50) NOT NULL,
  apellido VARCHAR(50) NOT NULL,
  dni VARCHAR(20) UNIQUE NOT NULL,
  fecha_nacimiento DATE NOT NULL,
  direccion VARCHAR(150) NULL,
  telefono VARCHAR(20) NOT NULL,
  correo VARCHAR(100) UNIQUE NOT NULL,
  nroLicencia VARCHAR(50) NOT NULL,
  vencimientoLicencia DATE NOT NULL,
  estadoIdentidad VARCHAR(50) NOT NULL,
  activo BIT NOT NULL DEFAULT 1,
  PRIMARY KEY (id_cliente)
);

-- 3. Tablas Dependientes de Nivel 2
CREATE TABLE Vehiculo
(
  id_vehiculo INT IDENTITY(1,1) NOT NULL,
  matricula VARCHAR(15) UNIQUE NOT NULL,
  chasis VARCHAR(30) UNIQUE NOT NULL,
  color VARCHAR(30) NOT NULL,
  anio INT NOT NULL,
  activo BIT NOT NULL DEFAULT 1,
  id_modelo INT NOT NULL,
  id_categoria INT NOT NULL,
  PRIMARY KEY (id_vehiculo),
  FOREIGN KEY (id_modelo) REFERENCES Modelo(id_modelo),
  FOREIGN KEY (id_categoria) REFERENCES Categoria(id_categoria)
);

-- 4. Tablas Operacionales
CREATE TABLE Reserva
(
  id_reserva INT IDENTITY(1,1) NOT NULL,
  precio_diario_pactado DECIMAL(10,2) NOT NULL,
  fecha_solicitud DATETIME DEFAULT GETDATE(),
  fecha_inicio_reserva DATETIME NOT NULL,
  fecha_fin_reserva DATETIME NOT NULL,
  activo BIT NOT NULL DEFAULT 1,
  id_estado INT NOT NULL,
  id_empleado INT NOT NULL,
  id_vehiculo INT NOT NULL,
  id_cliente INT NOT NULL,
  PRIMARY KEY (id_reserva),
  FOREIGN KEY (id_estado) REFERENCES Estado(id_estado),
  FOREIGN KEY (id_empleado) REFERENCES Empleado(id_empleado),
  FOREIGN KEY (id_vehiculo) REFERENCES Vehiculo(id_vehiculo),
  FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente)
);

CREATE TABLE Alquiler
(
  id_alquiler INT IDENTITY(1,1) NOT NULL,
  fechaEntregaReal DATETIME NOT NULL,
  fechaEntregaDevolucion DATETIME NULL,
  combustibleSalida DECIMAL(5,2) NOT NULL,
  combustibleEntrada DECIMAL(5,2) NULL,
  kilometrajeSalida DECIMAL(10,2) NOT NULL,
  kilometrajeEntrada DECIMAL(10,2) NULL,
  montoMora DECIMAL(10,2) DEFAULT 0,
  activo BIT NOT NULL DEFAULT 1,
  id_reserva INT NOT NULL,
  PRIMARY KEY (id_alquiler),
  FOREIGN KEY (id_reserva) REFERENCES Reserva(id_reserva)
);

CREATE TABLE Danio
(
  id_danio INT IDENTITY(1,1) NOT NULL,
  zona VARCHAR(50) NOT NULL,
  descripcion VARCHAR(255) NOT NULL,
  evidenciaFotografica VARCHAR(255) NULL,
  activo BIT NOT NULL DEFAULT 1,
  id_alquiler INT NOT NULL,
  PRIMARY KEY (id_danio),
  FOREIGN KEY (id_alquiler) REFERENCES Alquiler(id_alquiler)
);