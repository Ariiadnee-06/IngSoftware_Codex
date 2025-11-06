💻 Sistema de Recomendación de Computadoras por Chatbox

Este proyecto es un sistema de recomendación de computadoras que funciona a través de un chatbox interactivo, el cual analiza las respuestas del usuario para ofrecerle una computadora que se ajuste a sus necesidades.
El sistema fue desarrollado con C#, .NET y Entity Framework Core, usando MySQL como base de datos administrada desde phpMyAdmin.

🚀 Características principales

Chatbox inteligente que recomienda computadoras según las preferencias del usuario.

Conexión a base de datos MySQL mediante Entity Framework Core.

Panel de administración y almacenamiento estructurado de información.

Arquitectura basada en principios de Programación Orientada a Objetos (POO).

⚙️ Requisitos previos

Antes de ejecutar el proyecto, asegúrate de tener instalados los siguientes programas:

Visual Studio 2022

.NET 6 o superior

XAMPP

📦 Instalación de dependencias

Abre la Consola del Administrador de Paquetes (Package Manager Console) en Visual Studio y ejecuta los siguientes comandos:

Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools


📝 Nota:
Si tu conexión es con MySQL, también puedes instalar el proveedor correspondiente:

Install-Package Pomelo.EntityFrameworkCore.MySql

🗄️ Creación y actualización de la base de datos

Una vez configurada tu base de datos en phpMyAdmin, ejecuta este comando para generar las tablas según tus modelos de Entity Framework:

Update-Database


Esto aplicará las migraciones y sincronizará la base de datos con la estructura del proyecto.
