# 🧠 Manual Técnico – RadioDemo

## 🛠️ Requisitos del Proyecto

Este proyecto está construido utilizando las siguientes tecnologías:

- **.NET 8 (ASP.NET MVC)** para el backend web.
- **C#** como lenguaje principal.
- **MySQL 9** como base de datos relacional.
- **MongoDB** para almacenamiento de archivos PDF.
- **DinkToPdf** para generación de contratos en formato PDF.
- **Bootstrap y Razor (.cshtml)** para la interfaz de usuario.
- **Visual Studio 2022** como entorno de desarrollo.
- **Librería `libwkhtmltox.dll`** como dependencia para generación de PDF.

## 📂 Estructura del Proyecto

El proyecto está organizado de la siguiente manera:

- **`Controllers/`**: Controladores ASP.NET MVC que manejan la lógica de cada módulo (Login, Contrato, Anunciante, etc.).
- **`Models/`**: Clases modelo que representan las entidades del sistema.
- **`Data/`**:
  - `Procedimientos.cs`: Contiene la lógica para interactuar con la base de datos MySQL.
  - `ConexionMongo.cs`: Maneja la conexión con MongoDB y el guardado/lectura de archivos PDF.
- **`Views/`**: Vistas `.cshtml` organizadas por módulo.
- **`wwwroot/`**: Archivos estáticos (CSS, JS y librerías).
- **`DB/`**:
  - `radio_demo.sql`: Script de creación de base de datos MySQL.
  - `radio_demo.Documento.json`: Documentos PDF almacenados para uso en MongoDB.

## 💻 Instalación y Configuración

1. Clona el repositorio:

   ```bash
   git clone https://github.com/SebastianSierra15/RadioDemo.git
   ```

2. Crea la base de datos ejecutando el script:

   ```bash
   DB/radio_demo.sql
   ```

3. Configura las credenciales de conexión a MySQL en:

   ```
   Data/Conexion.cs
   ```

4. Asegúrate de tener **MongoDB** ejecutándose localmente (por defecto en el puerto `27017`).\
   Si deseas usar un servidor remoto, autenticación o cambiar el nombre de la base de datos:

   - Edita la cadena de conexión en:

     ```
     Data/ConexionMongo.cs
     ```

   - Reemplaza:

     ```csharp
     var client = new MongoClient("mongodb://localhost:27017");
     ```

     Por tu configuración personalizada, por ejemplo:

     ```csharp
     var client = new MongoClient("mongodb://usuario:clave@host:puerto");
     ```

5. Ejecuta el proyecto desde **Visual Studio**. La vista de inicio es:

   ```
   /Login/Index
   ```

## 🧾 Generación de PDF

- El sistema no genera reportes genéricos.
- Solo genera contratos en **formato PDF** utilizando la librería **DinkToPdf**, que renderiza la vista `/Contrato/VistaPDF`.
- La visualización previa del contrato se genera en una vista HTML y luego se convierte en PDF automáticamente.
- Los archivos PDF generados se almacenan en **MongoDB** y quedan disponibles para su descarga desde la vista principal de contratos.

## 🧑‍💻 Clases Clave

- **`ContratoController.cs`**: Lógica de creación, validación y generación de contratos.
- **`Procedimientos.cs`**: Acceso a procedimientos almacenados en MySQL.
- **`ConexionMongo.cs`**: Interacción con MongoDB para guardar y recuperar archivos PDF.
- **`Program.cs`**: Configuración global del servidor, autenticación, manejo de errores y enrutamiento.

## 🤝 Contribuciones

Si deseas contribuir al proyecto, sigue estos pasos:

1. Realiza un fork del repositorio.
2. Crea una nueva rama con tu funcionalidad o corrección.
3. Abre un pull request explicando los cambios realizados.

---

📌 Para cualquier duda técnica, consulta el archivo [`Autores.md`](./Autores.md) y contacta directamente al desarrollador del sistema.
