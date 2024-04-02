# Entity Framework Core (EF Core)

Entity Framework core (EF Core) es un framework de object-relational mapping (ORM) open-source desarrollado por Microsoft. Es una version mas ligera, extensible y multiplataforma de Entity Framework, diseñada para trabajar en proyectos de .NET Core. EF Core le permite a los desarrolladores trabajr con base de datos relacionales usando objetos fuertemente tipados en .NET. EF Core es una abstraccion a la complejidad de interactuar directamente con una base de datos.

Este framework resuelve muchas interacciones de bajo nivel con una base de datos, esto es una ventaja para los desarrolladores, ya que les permite crear, mantener e interactuar con una base de datos en unos simples pasos.

Algunos puntos fundamentales sobre ef core:

- Model first: ef core permite a los desarrolladores definir el esquema de base de datos usando entidades. Las clases representan tablas y las propiedades serian las columnas de las tablas.

- Code first: alternativamente, los desarrolladores pueden comenzar con clases del dominio y hacer uso de herramientas de migracion para generar el esquema de base de datos basandose en esas clases.

- Soporte LINQ: EF Core soporta LINQ (Language Integrated Query), lo cual permite a los desarrolladores escribir queries usando una sintaxis en C# en vez de queries crudas en SQL. Esto hace que realizar queries sea mas natural e intuitivo.

- Compatibilidad multi plataforma: esta diseñado para trabajar en multiples plataformas, incluyendo Windows, Linux y macOS. Esto hace que sea una opcion acorde a la hora de crear aplicaciones que necesitan ser corridas en diferentes sistemas operativos.

- Soporte de migraciones: EF Core incluye herramientas para gestionar los cambios que sufre el esquema de la base de datos. Los desarrolladores pueden crear y aplicar migraciones para actualizar el esquema de la base de datos a lo largo que la aplicacion evoluciona.

- Mejoras de performance: EF Core esta diseñado para ser mas rapido y mas eficiente que su version anterior, Entity Framework 6. Logra esto mediante varias optimizaciones, como una mejor compilacion de queries y reduccion de overhead.

- Soporte para diferentes motores de base de datos: EF Core soporta un gran numero de motores de base de datos, alguno de ellos son: SQL Server, SQLite, MySQL, PostgreSQL, y otros mas. Esto le permite al desarrollador usar el motor de base de datos que prefiera sin cambiar ningun codigo en su aplicacion.

- Integracion de inyeccion de dependencia: EF Core interactua muy facilmente con el built-in contenedor de servicios de ASP.NET Core, haciendo que sea facil manejar el ciclo de vida de los contextos de la base de datos y otros componentes de EF Core.

- Extensibilidad: EF Core esta diseñado para ser extensible, esto le permite a los desarrolladores customizar su comportamiento segun las especificaciones que requieran. Esto puede ser logrado por convenciones, configuraciones o extendiendo metodos.

- Ejecucion de queries async: EF Core soporta ejecuciones asincronas, que le permite a la aplicacion ejecutar operaciones de forma asincrona contra la base de datos, esto mejora la esalabilidad de la aplicacion.

En resumen, EF Core simplifica el acceso a datos al proveer un ORM flexible y poderoso que abstrae muchas complejidades a la hora de trabajar con base de datos relacional. Este ORM puede ayudar a mejorar la productividad del equipo por la gran abstraccion que ofrece.