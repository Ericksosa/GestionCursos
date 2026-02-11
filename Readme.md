# Sistema de Gestión de Cursos y Estudiantes

![.NET](https://img.shields.io/badge/.NET-9.0-purple)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-SQL%20Server-blue)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5-orange)
![Status](https://img.shields.io/badge/Status-Finalizado-green)

Este proyecto es una aplicación web desarrollada bajo el patrón de arquitectura **MVC (Modelo-Vista-Controlador)** utilizando **ASP.NET Core 9**. Su objetivo principal es administrar la matrícula académica, gestionando estudiantes, cursos e inscripciones, e incluye un módulo de **Inteligencia de Negocios (BI)** para la toma de decisiones.

---

##  Características Principales

### 1. Gestión de Datos (CRUD Completo)
El sistema permite realizar operaciones de Crear, Leer, Actualizar y Eliminar (CRUD) en las siguientes entidades:
* **Estudiantes:** Gestión de datos personales (Nombre, Apellido, Email).
* **Cursos:** Administración del catálogo académico (Título, Créditos, Descripción).
* **Inscripciones:** Vinculación relacional entre estudiantes y cursos con fecha de registro.

### 2. Inteligencia de Negocios (Business Intelligence) 
El sistema cuenta con un **Dashboard Interactivo** en la página principal que muestra métricas en tiempo real:
* **KPIs (Indicadores Clave):** Contadores totales de Estudiantes, Cursos e Inscripciones activas.
* **Análisis de Tendencias:** Gráfico de barras visualizando los "Top 3 Cursos más Populares" basado en la cantidad de inscritos.

### 3. Arquitectura y Persistencia
* **ORM:** Uso de **Entity Framework Core** para la manipulación de datos.
* **Base de Datos:** SQL Server.
* **Acceso a Datos:** Uso de **LINQ** para consultas eficientes y seguras.
* **Diseño:** Interfaz moderna y responsiva utilizando **Bootstrap 5** y **Bootstrap Icons**.

---

##  Tecnologías Utilizadas

* **Framework:** .NET 9 (ASP.NET Core MVC)
* **Lenguaje:** C#
* **Base de Datos:** SQL Server (LocalDB)
* **Frontend:** Razor Views (.cshtml), Bootstrap 5, CSS3.
* **Herramientas:** Visual Studio / VS Code, Git.

---

##  Modelo de Base de Datos

La aplicación utiliza un modelo relacional normalizado:

* **Tabla `Estudiantes`** (1) <-----> (N) **Tabla `Inscripciones`**
* **Tabla `Cursos`** (1) <-----> (N) **Tabla `Inscripciones`**

La tabla `Inscripciones` actúa como entidad intermedia para resolver la relación muchos a muchos, almacenando además la fecha de la transacción.

---

##  Instrucciones de Instalación y Ejecución

Sigue estos pasos para ejecutar el proyecto en tu entorno local:

### 1. Clonar el Repositorio
```bash
git clone https://github.com/Ericksosa/GestionCursos.git
cd GestionDeCursos