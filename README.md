# 📻 RadioDemo – Sistema de Gestión de Contratos Radiales

**RadioDemo** es un sistema de información web creado como proyecto educativo universitario, orientado a la gestión de anunciantes, contratos, vendedores, programas y tarifas dentro de una emisora radial.

Desarrollado como ejercicio de consolidación de conocimientos en ASP.NET MVC, bases de datos relacionales y no relacionales, y generación de documentos PDF. Aunque su enfoque fue académico, el sistema funciona como una base sólida para soluciones reales.

---

## 🚀 Tecnologías utilizadas

- .NET 8 (ASP.NET MVC)
- C#
- MySQL 9
- MongoDB
- Bootstrap
- DinkToPdf (wkhtmltopdf)
- Visual Studio 2022

---

## 📄 Documentación

- [📸 Capturas del sistema](docs/Capturas.md)
- [🧠 Manual técnico (desarrolladores)](docs/ManualTecnico.md)
- [👥 Manual de usuario (uso del sistema)](docs/ManualUsuario.md)
- [👤 Autores y créditos](docs/Autores.md)

---

## ⚙️ Instalación rápida

### 🔧 Requisitos

- Visual Studio 2022
- .NET SDK 8.0
- MySQL 9
- MongoDB
- Navegador moderno

### 🧪 Pasos

1. Clona este repositorio:

   ```bash
   git clone https://github.com/SebastianSierra15/RadioDemo.git
   ```

2. Crea la base de datos ejecutando el archivo SQL ubicado en:

   ```
   DB/radio_demo.sql
   ```

3. Configura las credenciales de conexión a MySQL en:

   ```
   Data/Conexion.cs
   ```

4. Configura la conexión a MongoDB en:

   ```
   Data/ConexionMongo.cs
   ```

5. Ejecuta el proyecto desde Visual Studio.

6. Accede al sistema desde el navegador:

   ```
   http://localhost:5000/Login/Index
   ```

---

## 📸 Vistas principales

| Dashboard                         | Contratos                          | Crear Contrato                   |
|----------------------------------|------------------------------------|----------------------------------|
| ![Dashboard](assets/home.png)    | ![Contratos](assets/contratos.png) | ![Crear](assets/crear-contrato.png) |

---

## 📩 Contacto

Proyecto desarrollado por [Sebastián Sierra](docs/Autores.md).\
Para más información o colaboración: [sebsirra13@gmail.com](mailto\:sebsirra13@gmail.com)

---

## 👤 Usuarios de prueba

Puedes acceder al sistema con los siguientes usuarios incluidos en la base de datos:

| Rol      | Usuario   | Contraseña |
| -------- | --------- | ---------- |
| Admin    | admin     | 12345      |
| Empleado | empleado  | 12345      |
| Invitado | invitado  | 12345      |

> ⚠️ Estos usuarios son solo de prueba. Puedes modificarlos o eliminarlos desde el módulo de Vendedores.

---

## 📜 Licencia

Este proyecto fue realizado como parte de un ejercicio académico y de formación técnica.

### Licencia

Este software está bajo la **Licencia Creative Commons Attribution 4.0 International (CC BY 4.0)**, lo cual permite:

- Uso comercial
- Distribución
- Modificación
- Uso privado o empresarial

Siempre y cuando se mantenga la atribución adecuada al autor.

Consulta el archivo [LICENSE.txt](LICENSE.txt) para más detalles.

