/*CREATE DATABASE [BD_Barberia];
GO

USE [BD_Barberia];
GO

CREATE TABLE [Clientes] (
    [ID_Cliente] INT PRIMARY KEY IDENTITY(1,1),
    [Cedula] VARCHAR(20) NOT NULL,
    [Nombre] VARCHAR(100) NOT NULL,
    [Telefono] VARCHAR(15),
    [Correo_Electronico] VARCHAR(100),
    [Fecha_Nacimiento] DATE
);

CREATE TABLE [Barberos] (
    [ID_Barbero] INT PRIMARY KEY IDENTITY(1,1),
    [Cedula] VARCHAR(20) NOT NULL,
    [Nombre] VARCHAR(100) NOT NULL,
    [Telefono] VARCHAR(15),
    [Especialidad] VARCHAR(100),
    [Activo] BIT DEFAULT 1
);

CREATE TABLE [Servicios] (
    [ID_Servicio] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] VARCHAR(100) NOT NULL,
    [Descripcion] TEXT,
    [Duracion_Minutos] INT,
    [Precio_Actual] DECIMAL(10,2),
    [Activo] BIT DEFAULT 1
);

CREATE TABLE [Citas] (
    [ID_Cita] INT PRIMARY KEY IDENTITY(1,1),
    [ID_Cliente] INT REFERENCES [Clientes]([ID_Cliente]),
    [ID_Barbero] INT REFERENCES [Barberos]([ID_Barbero]),
    [Fecha_Hora] DATETIME,
    [Estado] VARCHAR(50),
    [Notas_Adicionales] TEXT
);
CREATE TABLE [Metodos_Pago] (
    [ID_Metodo] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] VARCHAR(50) NOT NULL,
    [Descripcion] TEXT,
    [Activo] BIT DEFAULT 1
);

CREATE TABLE [Categorias_Producto] (
    [ID_Categoria] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] VARCHAR(100) NOT NULL,
    [Descripcion] TEXT,
    [Activo] BIT DEFAULT 1
);

CREATE TABLE [Proveedores] (
    [ID_Proveedor] INT PRIMARY KEY IDENTITY(1,1),
    [NIT] VARCHAR(20) NOT NULL,
    [Nombre_Empresa] VARCHAR(100) NOT NULL,
    [Contacto_Principal] VARCHAR(100),
    [Telefono] VARCHAR(15),
    [Email] VARCHAR(100)
);

CREATE TABLE [Sucursales] (
    [ID_Sucursal] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] VARCHAR(100) NOT NULL,
    [Direccion] VARCHAR(200),
    [Telefono] VARCHAR(15),
    [Ciudad] VARCHAR(50),
    [Activa] BIT DEFAULT 1
);

CREATE TABLE [Promociones] (
    [ID_Promocion] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] VARCHAR(100) NOT NULL,
    [Tipo_Descuento] VARCHAR(50),
    [Valor_Descuento] DECIMAL(10,2),
    [Fecha_Inicio] DATE,
    [Fecha_Fin] DATE,
    [Activo] BIT DEFAULT 1
);

CREATE TABLE [Roles] (
    [ID_Rol] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] VARCHAR(50) NOT NULL,
    [Descripcion] TEXT,
    [Activo] BIT DEFAULT 1
);

CREATE TABLE [Permisos] (
    [ID_Permiso] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre_Permiso] VARCHAR(100) NOT NULL,
    [Modulo_App] VARCHAR(50),
    [Descripcion] TEXT
);

CREATE TABLE [Cita_Servicios] (
    [ID_Cita_Servicio] INT PRIMARY KEY IDENTITY(1,1),
    [ID_Cita] INT REFERENCES [Citas]([ID_Cita]),
    [ID_Servicio] INT REFERENCES [Servicios]([ID_Servicio]),
    [Precio_Cobrado] DECIMAL(10,2),
    [Descuento_Aplicado] DECIMAL(10,2)
);

CREATE TABLE [Pagos] (
    [ID_Pago] INT PRIMARY KEY IDENTITY(1,1),
    [ID_Cita] INT REFERENCES [Citas]([ID_Cita]),
    [ID_Metodo] INT REFERENCES [Metodos_Pago]([ID_Metodo]),
    [Monto_Total] DECIMAL(10,2),
    [Fecha_Pago] DATETIME,
    [Referencia_Voucher] VARCHAR(100)
);

CREATE TABLE [Horarios_Disponibilidad] (
    [ID_Horario] INT PRIMARY KEY IDENTITY(1,1),
    [ID_Barbero] INT REFERENCES [Barberos]([ID_Barbero]),
    [Dia_Semana] VARCHAR(20),
    [Hora_Inicio] TIME,
    [Hora_Fin] TIME,
    [Estado] VARCHAR(50)
);

CREATE TABLE [Productos] (
    [ID_Producto] INT PRIMARY KEY IDENTITY(1,1),
    [ID_Categoria] INT REFERENCES [Categorias_Producto]([ID_Categoria]),
    [ID_Proveedor] INT REFERENCES [Proveedores]([ID_Proveedor]),
    [Nombre] VARCHAR(100) NOT NULL,
    [Codigo_Barras] VARCHAR(50),
    [Precio_Venta] DECIMAL(10,2),
    [Stock_Actual] INT
);

CREATE TABLE [Venta_Productos] (
    [ID_Venta] INT PRIMARY KEY IDENTITY(1,1),
    [ID_Cliente] INT REFERENCES [Clientes]([ID_Cliente]),
    [ID_Barbero] INT REFERENCES [Barberos]([ID_Barbero]),
    [Fecha_Venta] DATETIME,
    [Total_Venta] DECIMAL(10,2),
    [Estado_Venta] VARCHAR(50)
);

CREATE TABLE [Detalle_Venta_Productos] (
    [ID_Detalle] INT PRIMARY KEY IDENTITY(1,1),
    [ID_Venta] INT REFERENCES [Venta_Productos]([ID_Venta]),
    [ID_Producto] INT REFERENCES [Productos]([ID_Producto]),
    [Cantidad] INT,
    [Precio_Unitario] DECIMAL(10,2),
    [Subtotal] DECIMAL(10,2)
);

CREATE TABLE [Cajas_Diarias] (
    [ID_Caja] INT PRIMARY KEY IDENTITY(1,1),
    [ID_Sucursal] INT REFERENCES [Sucursales]([ID_Sucursal]),
    [Fecha_Apertura] DATETIME,
    [Saldo_Inicial] DECIMAL(10,2),
    [Saldo_Final] DECIMAL(10,2),
    [Estado_Caja] VARCHAR(50)
);

CREATE TABLE [Rol_Permisos] (
    [ID_Rol_Permiso] INT PRIMARY KEY IDENTITY(1,1),
    [ID_Rol] INT REFERENCES [Roles]([ID_Rol]),
    [ID_Permiso] INT REFERENCES [Permisos]([ID_Permiso]),
    [Fecha_Asignacion] DATE,
    [Habilitado] BIT DEFAULT 1
);

CREATE TABLE [Usuarios] (
    [ID_Usuario] INT PRIMARY KEY IDENTITY(1,1),
    [ID_Rol] INT REFERENCES [Roles]([ID_Rol]),
    [ID_Barbero] INT REFERENCES [Barberos]([ID_Barbero]),
    [Nombre_Usuario] VARCHAR(50) NOT NULL,
    [Hash_Contrasena] VARCHAR(255) NOT NULL,
    [Ultimo_Acceso] DATETIME
);


INSERT INTO [Clientes] ([Cedula], [Nombre], [Telefono], [Correo_Electronico], [Fecha_Nacimiento]) VALUES
('10001', 'Andrés Felipe Ríos', '3001112233', 'andres@mail.com', '1995-04-12'),
('10002', 'María Camila López', '3102223344', 'maria@mail.com', '1998-08-25'),
('10003', 'Sebastián Gómez', '3203334455', 'sebastian@mail.com', '1990-11-05'),
('10004', 'Valentina Torres', '3004445566', 'vale@mail.com', '2001-02-18'),
('10005', 'Jorge Martínez', '3115556677', 'jorge@mail.com', '1985-07-30');

INSERT INTO [Barberos] ([Cedula], [Nombre], [Telefono], [Especialidad], [Activo]) VALUES
('20001', 'Carlos Pérez', '3009998877', 'Barba y Degradado', 1),
('20002', 'Luis Roldán', '3108887766', 'Cortes Clásicos', 1),
('20003', 'David Quintero', '3207776655', 'Colorimetría', 1),
('20004', 'Santiago Yepes', '3006665544', 'Freestyle', 1),
('20005', 'Daniel Osorio', '3115554433', 'Corte con Tijera', 0);

INSERT INTO [Servicios] ([Nombre], [Descripcion], [Duracion_Minutos], [Precio_Actual], [Activo]) VALUES
('Corte Clásico', 'Corte a tijera o máquina tradicional', 30, 20000.00, 1),
('Arreglo de Barba', 'Perfilado y ritual de toalla caliente', 20, 15000.00, 1),
('Corte + Barba', 'Paquete completo de corte y barba', 45, 30000.00, 1),
('Tinte y Color', 'Colorimetría y platinados', 90, 80000.00, 1),
('Limpieza Facial', 'Mascarilla negra y exfoliación', 40, 40000.00, 1);

INSERT INTO [Metodos_Pago] ([Nombre], [Descripcion], [Activo]) VALUES
('Efectivo', 'Pago en moneda física en caja', 1),
('Tarjeta de Crédito', 'Terminal punto de venta (Datáfono)', 1),
('Transferencia', 'Transferencia bancaria directa', 1),
('Nequi', 'Pago con código QR Nequi', 1),
('Bancolombia', 'Pago con código QR Bancolombia', 1);

INSERT INTO [Categorias_Producto] ([Nombre], [Descripcion], [Activo]) VALUES
('Cuidado Capilar', 'Shampoos, geles y ceras', 1),
('Cuidado de Barba', 'Aceites, bálsamos y aftershaves', 1),
('Herramientas', 'Máquinas, tijeras y navajas', 1),
('Cuidado Facial', 'Cremas y mascarillas', 1),
('Bebidas', 'Gaseosas, cervezas y aguas', 1);

INSERT INTO [Proveedores] ([NIT], [Nombre_Empresa], [Contacto_Principal], [Telefono], [Email]) VALUES
('900111222', 'Insumos Barber S.A.S', 'Carlos Muñoz', '3001110000', 'ventas@insumos.com'),
('900222333', 'Wahl Colombia', 'Andrea Jiménez', '3102220000', 'andrea@wahl.co'),
('900333444', 'Suavecito Dist', 'Luis Franco', '3203330000', 'contacto@suavecito.co'),
('900444555', 'Distribuidora Belleza', 'Ana Gómez', '3004440000', 'gerencia@belleza.com'),
('900555666', 'Cervecería Local', 'Pedro Pérez', '3115550000', 'pedidos@cerveceria.com');

INSERT INTO [Sucursales] ([Nombre], [Direccion], [Telefono], [Ciudad], [Activa]) VALUES
('Sede Laureles', 'Av. Nutibara # 39-20', '6041112233', 'Medellín', 1),
('Sede Poblado', 'Calle 10 #40-50', '6042223344', 'Medellín', 1),
('Sede Envigado', 'Cra 43A # 30-10', '6043334455', 'Envigado', 1),
('Sede Bello', 'Parque Principal', '6044445566', 'Bello', 1),
('Sede Rionegro', 'Mall Llanogrande', '6045556677', 'Rionegro', 0);

INSERT INTO [Promociones] ([Nombre], [Tipo_Descuento], [Valor_Descuento], [Fecha_Inicio], [Fecha_Fin], [Activo]) VALUES
('Martes de Estudiantes', 'Porcentaje (%)', 20.00, '2026-01-01', '2026-12-31', 1),
('Día del Padre', 'Monto Fijo ($)', 10000.00, '2026-06-01', '2026-06-30', 0),
('Black Friday', 'Porcentaje (%)', 30.00, '2026-11-20', '2026-11-30', 0),
('Combo Cumpleañero', 'Porcentaje (%)', 50.00, '2026-01-01', '2026-12-31', 1),
('2x1 en Cervezas', 'Producto Extra', 100.00, '2026-08-01', '2026-08-31', 1);

INSERT INTO [Roles] ([Nombre], [Descripcion], [Activo]) VALUES
('Administrador', 'Acceso total a todos los módulos del sistema', 1),
('Barbero', 'Acceso a agenda propia y comisiones', 1),
('Recepcionista', 'Gestiona citas, clientes y caja diaria', 1),
('Cliente', 'Acceso a app móvil para reservar citas', 1),
('Auditor', 'Acceso de solo lectura a reportes financieros', 1);

INSERT INTO [Permisos] ([Nombre_Permiso], [Modulo_App], [Descripcion]) VALUES
('Ver Agenda Global', 'Agenda', 'Permite visualizar el calendario de todos'),
('Cobrar Cita', 'Facturación', 'Permite generar cobros y facturas'),
('Gestionar Inventario', 'Inventario', 'Crear, editar y dar de baja productos'),
('Ver Reportes', 'Reportes', 'Acceso a métricas de ingresos y ventas'),
('Configurar Sistema', 'Ajustes', 'Cambiar parámetros y crear usuarios');

INSERT INTO [Citas] ([ID_Cliente], [ID_Barbero], [Fecha_Hora], [Estado], [Notas_Adicionales]) VALUES
(1, 1, '2026-08-28 10:00:00', 'Completada', 'Ninguna'),
(2, 3, '2026-08-28 11:00:00', 'Pendiente', 'Cliente VIP'),
(3, 1, '2026-08-28 14:00:00', 'Pendiente', 'Piel sensible'),
(4, 4, '2026-08-29 09:00:00', 'Cancelada', 'Reprogramará luego'),
(5, 2, '2026-08-29 16:00:00', 'Confirmada', 'Llega 5 min tarde');

INSERT INTO [Cita_Servicios] ([ID_Cita], [ID_Servicio], [Precio_Cobrado], [Descuento_Aplicado]) VALUES
(1, 3, 30000.00, 0.00),
(2, 4, 75000.00, 5000.00),
(3, 1, 20000.00, 0.00),
(4, 5, 40000.00, 0.00),
(5, 2, 15000.00, 0.00);

INSERT INTO [Pagos] ([ID_Cita], [ID_Metodo], [Monto_Total], [Fecha_Pago], [Referencia_Voucher]) VALUES
(1, 1, 30000.00, '2026-08-28 10:45:00', NULL),
(2, 2, 75000.00, '2026-08-28 12:30:00', 'VOU-991'),
(3, 4, 20000.00, '2026-08-28 14:30:00', 'NEQ12345-'),
(4, 3, 40000.00, '2026-08-29 09:40:00', 'BAN-45678'),
(5, 1, 15000.00, '2026-08-29 16:20:00', NULL);

INSERT INTO [Horarios_Disponibilidad] ([ID_Barbero], [Dia_Semana], [Hora_Inicio], [Hora_Fin], [Estado]) VALUES
(1, 'Lunes', '09:00', '18:00', 'Activo'),
(1, 'Martes', '09:00', '18:00', 'Activo'),
(2, 'Miércoles', '10:00', '19:00', 'Activo'),
(3, 'Jueves', '08:00', '16:00', 'Activo'),
(4, 'Viernes', '12:00', '20:00', 'Activo');

INSERT INTO [Productos] ([ID_Categoria], [ID_Proveedor], [Nombre], [Codigo_Barras], [Precio_Venta], [Stock_Actual]) VALUES
(1, 3, 'Pomada Suavecito Firme', '7701234567890', 45000.00, 25),
(2, 1, 'Aceite para Barba', '7701234567891', 25000.00, 40),
(3, 2, 'Máquina Magic Clip', '7701234567892', 450000.00, 5),
(4, 4, 'Mascarilla Puntos Negros', '7701234567893', 15000.00, 50),
(5, 5, 'Cerveza Artesanal', '7701234567894', 8000.00, 100);

INSERT INTO [Venta_Productos] ([ID_Cliente], [ID_Barbero], [Fecha_Venta], [Total_Venta], [Estado_Venta]) VALUES
(1, 1, '2026-08-28 10:50:00', 45000.00, 'Pagada'),
(2, NULL, '2026-08-28 11:30:00', 15000.00, 'Pagada'),
(3, 3, '2026-08-29 14:15:00', 450000.00, 'Pagada'),
(4, 2, '2026-08-29 09:30:00', 8000.00, 'Pagada'),
(5, NULL, '2026-08-30 15:00:00', 50000.00, 'Pendiente');

INSERT INTO [Detalle_Venta_Productos] ([ID_Venta], [ID_Producto], [Cantidad], [Precio_Unitario], [Subtotal]) VALUES
(1, 1, 1, 45000.00, 45000.00),
(2, 4, 1, 15000.00, 15000.00),
(3, 3, 1, 450000.00, 450000.00),
(4, 5, 1, 8000.00, 8000.00),
(5, 2, 2, 25000.00, 50000.00);

INSERT INTO [Cajas_Diarias] ([ID_Sucursal], [Fecha_Apertura], [Saldo_Inicial], [Saldo_Final], [Estado_Caja]) VALUES
(1, '2026-08-28 08:00:00', 150000.00, 850000.00, 'Cerrada'),
(2, '2026-08-28 08:00:00', 200000.00, 920000.00, 'Cerrada'),
(1, '2026-08-29 08:00:00', 150000.00, 400000.00, 'Abierta'),
(2, '2026-08-29 08:00:00', 200000.00, 350000.00, 'Abierta'),
(3, '2026-08-29 08:00:00', 100000.00, 100000.00, 'Abierta');

INSERT INTO [Rol_Permisos] ([ID_Rol], [ID_Permiso], [Fecha_Asignacion], [Habilitado]) VALUES
(1, 1, '2026-01-01', 1),
(1, 2, '2026-01-01', 1),
(1, 3, '2026-01-01', 1),
(2, 1, '2026-01-02', 1),
(3, 2, '2026-01-05', 1);

INSERT INTO [Usuarios] ([ID_Rol], [ID_Barbero], [Nombre_Usuario], [Hash_Contrasena], [Ultimo_Acceso]) VALUES
(1, NULL, 'admin_juan', 'hash_abc123***', '2026-08-27 08:00:00'),
(2, 1, 'carlos barber', 'hash_xyz789***', '2026-08-27 09:30:00'),
(2, 2, 'luis_roldan', 'hash_def456***', '2026-08-26 18:45:00'),
(3, NULL, 'recep_sede1', 'hash_qwe789***', '2026-08-27 07:45:00'),
(5, NULL, 'auditor_ext', 'hash_aud321***', '2026-08-20 14:00:00');
/*