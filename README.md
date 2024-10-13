
# Mantenimiento Simple

Se creo un pequeño sistema de mantenimiento de usuarios con operaciones de autenticación usando JWT como sistema de seguridad.

## Instrucciones

#### Backend
- Primero debemos crear la base de datos **maintenanceDB** en PostgreSQL. Nos podemos ayudar del script.
```SQL
CREATE DATABASE "maintenanceDB";
```

- Segundo, debemos ajustar la cadena de conexion en el archivo **appsettings.json** del proyecto Backend. Donde ingresaremos el username y contraseña de acceso a PostgreSQL
```JSON
"ConnectionStrings": {
  "MaintenanceConnection": "Host=localhost;Port=5432;Database=maintenanceDB;Username=username;Password=password;"
}
```

- Tercero, iniciamos el proyecto Backend ejecutandolo desde VisualStudio2022
#### Nota:
El proyecto **Backend** esta configurado a iniciar en el puerto **7211** segun VisualStudio2022

#### FrontEnd

- Al descargar el proyecto, debemos ejecutar el siguiente comando en la raiz de la carpeta **Frontend**
```bash
  npm install 
```

- Luego verificamos que el puerto de la API del proyecto Backend sea el **7211**, caso contrario debemos actualizar el puerto en el archivo **constants.js** ubicado en el proyecto **FrontEnd/src/constants**

- Para iniciar la aplicacion Frontend, usaremos el comando
```bash
  npm run dev 
```

#### Nota:
Los accesos por defecto a usar son: 

Usuario: **admin@test.com**

Contraseña: **admin**



## Tech Stack

**Client:** React, react-router, TailwindCSS, Axios

**Server:** .Net 6

