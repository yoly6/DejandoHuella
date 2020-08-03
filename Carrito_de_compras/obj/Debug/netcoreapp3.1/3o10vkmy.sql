IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(128) NOT NULL,
    [ProviderKey] nvarchar(128) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(128) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'00000000000000_CreateIdentitySchema', N'3.1.6');

GO

CREATE TABLE [Categoria] (
    [CategoriaId] int NOT NULL IDENTITY,
    [CategoriaNombre] nvarchar(max) NOT NULL,
    [FacturaDescripcion] nvarchar(max) NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY ([CategoriaId])
);

GO

CREATE TABLE [Cliente] (
    [ClienteId] int NOT NULL IDENTITY,
    [ClienteNombre] nvarchar(max) NOT NULL,
    [ClienteApellido] nvarchar(max) NOT NULL,
    [PersonaFechaNacimiento] datetime2 NULL,
    [ClienteEmail] nvarchar(max) NOT NULL,
    [ClienteDireccion] nvarchar(max) NOT NULL,
    [ClienteTelefono] nvarchar(max) NOT NULL,
    [ImageName] nvarchar(100) NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([ClienteId])
);

GO

CREATE TABLE [Producto] (
    [ProductosId] int NOT NULL IDENTITY,
    [ProductosNombre] nvarchar(max) NOT NULL,
    [ProductosPrecio] float NOT NULL,
    [ProductosStock] float NOT NULL,
    [CategoriaId] int NULL,
    [ImageName] nvarchar(100) NULL,
    CONSTRAINT [PK_Producto] PRIMARY KEY ([ProductosId]),
    CONSTRAINT [FK_Producto_Categoria_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categoria] ([CategoriaId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Factura] (
    [FacturaId] int NOT NULL IDENTITY,
    [ClienteId] int NULL,
    [FacturaFecha] datetime2 NULL,
    [FacturaDescripcion] nvarchar(max) NULL,
    CONSTRAINT [PK_Factura] PRIMARY KEY ([FacturaId]),
    CONSTRAINT [FK_Factura_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([ClienteId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Pago] (
    [PagoId] int NOT NULL IDENTITY,
    [ClienteId] int NULL,
    [PagoFecha] datetime2 NULL,
    [ModoPagoId] int NULL,
    CONSTRAINT [PK_Pago] PRIMARY KEY ([PagoId]),
    CONSTRAINT [FK_Pago_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([ClienteId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Detalle] (
    [DetalleId] int NOT NULL IDENTITY,
    [FacturaId] int NULL,
    [ProductoId] int NULL,
    [DetalleCantidad] int NULL,
    [DetallePrecio] float NULL,
    CONSTRAINT [PK_Detalle] PRIMARY KEY ([DetalleId]),
    CONSTRAINT [FK_Detalle_Factura_FacturaId] FOREIGN KEY ([FacturaId]) REFERENCES [Factura] ([FacturaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Detalle_Producto_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Producto] ([ProductosId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ModoPago] (
    [ModoPagoId] int NOT NULL IDENTITY,
    [ModoPagoDescripcion] nvarchar(max) NULL,
    [PagoId] int NULL,
    CONSTRAINT [PK_ModoPago] PRIMARY KEY ([ModoPagoId]),
    CONSTRAINT [FK_ModoPago_Pago_PagoId] FOREIGN KEY ([PagoId]) REFERENCES [Pago] ([PagoId]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Detalle_FacturaId] ON [Detalle] ([FacturaId]);

GO

CREATE INDEX [IX_Detalle_ProductoId] ON [Detalle] ([ProductoId]);

GO

CREATE INDEX [IX_Factura_ClienteId] ON [Factura] ([ClienteId]);

GO

CREATE INDEX [IX_ModoPago_PagoId] ON [ModoPago] ([PagoId]);

GO

CREATE INDEX [IX_Pago_ClienteId] ON [Pago] ([ClienteId]);

GO

CREATE INDEX [IX_Producto_CategoriaId] ON [Producto] ([CategoriaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200802204514_InitialCreate', N'3.1.6');

GO

ALTER TABLE [Cliente] ADD [ImageName] nvarchar(100) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200803174832_Imagen', N'3.1.6');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200803182950_Imagen.Desing', N'3.1.6');

GO

ALTER TABLE [Producto] ADD [ImageName] nvarchar(100) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200803184802_ImgProductos', N'3.1.6');

GO

