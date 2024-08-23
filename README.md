# FinanceManager

## Descripción

**FinanceManager** es una aplicación web que permite a los usuarios gestionar sus finanzas personales. Con esta aplicación, puedes registrar y categorizar movimientos financieros, tales como ingresos y egresos, permitiéndote llevar un control detallado de tus finanzas.

## Características

- Crear, editar y eliminar movimientos financieros.
- Clasificación de movimientos en categorías.
- Visualización detallada de cada movimiento financiero.
- Interfaz de usuario amigable y responsiva utilizando Bootstrap.

## Instalación

### Requisitos Previos

- .NET 6.0 SDK o superior
- Visual Studio 2022 o superior (opcional, para desarrollo)
- SQL Server (local o remoto) o cualquier otro sistema de gestión de bases de datos compatible

### Pasos de Instalación

1. **Clona el repositorio:**

   ```bash
   git clone https://github.com/tuusuario/FinanceManager.git
   cd FinanceManager

2. **Configura la base de datos:**

- Crea una base de datos llamada FinanceDB en SQL Server.
- Ejecuta las siguientes instrucciones SQL para crear las tablas:

```bash
    -- Tabla Secundaria: Categoria
        CREATE TABLE Categoria (
            Id INT IDENTITY(1,1) PRIMARY KEY,
            Nombre NVARCHAR(50) NOT NULL
        );

   -- Tabla Principal: Finanza
    CREATE TABLE Finanza (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Tipo NVARCHAR(10) NOT NULL CHECK (Tipo IN ('Ingreso', 'Egreso')),
        Monto DECIMAL(18,2) NOT NULL,
        Categoria NVARCHAR(50),
        Descripcion NVARCHAR(255),
        Fecha DATE NOT NULL,
        CategoriaId INT,
        CONSTRAINT FK_Finanza_Categoria FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id)
    );
    
    -- Contenido inicial de la tabla Categoria
    INSERT INTO Categoria (Nombre) VALUES 
    ('Nomina'), 
    ('Alimentacion'),
    ('Transporte'),
    ('Servicios'),
    ('Entretenimiento'),
    ('Hogar'),
    ('Salud'),
    ('Educacion'),
    ('Otros');
