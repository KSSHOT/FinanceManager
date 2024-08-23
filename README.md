# FinanceManager

## Descripción

**FinanceManager** es una aplicación web que permite a los usuarios gestionar sus finanzas personales. Con esta aplicación, puedes registrar y categorizar movimientos financieros, tales como ingresos y egresos, permitiéndote llevar un control detallado de tus finanzas, al mismo tiempo permite ver el capital actual con la diferencia entre ingresos y Egresos, esto con un apartado de ordenamiento cronologico.

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

```
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
```

- Actualiza el archivo appsettings.json con la cadena de conexión a tu base de datos:

3. **Instala las dependencias necesarias:**

En la consola del Administrador de Paquetes de Visual Studio, ejecuta:

```
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Bootstrap
```

4. **Aplica las migraciones de la base de datos:**

```
Add-Migration InitialCreate
Update-Database
```
## Uso

- Crear un movimiento: Desde la página principal, haz clic en "Agregar Movimiento" para registrar un nuevo ingreso o egreso.
- Editar o eliminar movimientos: En la lista de movimientos, utiliza las opciones de "Editar" o "Eliminar" para modificar o remover registros existentes.

## Capturas de Pantalla

1. *Pantalla Principal:*

![image](https://github.com/user-attachments/assets/f8bfae79-6b68-49e2-96cb-ebb44c1819d8)


2. *Formulario de Creación:*

![image](https://github.com/user-attachments/assets/ad7934ed-bb41-41fb-879a-9f600667a660)
![image](https://github.com/user-attachments/assets/cef6d659-cbb4-4485-86bd-d595b6c9e6a3)


3. *Edicion del Movimiento:*

![image](https://github.com/user-attachments/assets/36ad38fa-734d-4cc1-8faf-df09b9cb912d)


4. *Detalles del Movimiento:*

![image](https://github.com/user-attachments/assets/18c222df-cc4e-4725-b66c-ed6579e99767)


## Contribuciones

Las contribuciones son bienvenidas. Si deseas colaborar, por favor sigue los siguientes pasos:

1. Haz un fork del repositorio.
2. Crea una nueva rama (git checkout -b feature/nueva-funcionalidad).
3. Realiza tus cambios y realiza commits descriptivos (git commit -m 'Añadida nueva funcionalidad').
4. Sube tus cambios al repositorio (git push origin feature/nueva-funcionalidad).
5. Crea un Pull Request en GitHub.

## Licencia
Este proyecto está licenciado bajo la Licencia MIT. Para más detalles, consulta el archivo LICENSE.

## Autor

Oscar David Garcia Badillo - [Perfil en GitHub](https://github.com/KSSHOT)
