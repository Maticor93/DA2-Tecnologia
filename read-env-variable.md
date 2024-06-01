[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-service)

# Lectura de variable de ambiente

Las variables de ambiente deben ser dinamicas ya que sus valores dependen del ambiente en el cual la aplicacion deberia de correr. Por ejemplo cuando la aplicacion corre localmente espera que la api sea local tambien, cuando corremos la aplicacion en un ambiente `dev` esperamos que la api este corriendo en ese ambiente, y asi con los diferentes ambientes que pueden existir.

Nosotros vamos a utilizar dos ambientes: `local` y `prod`.

Primero debemos crear los archivos asociados a los ambientes que queremos utilizar. Estos archivos deben ubicarse en la carpeta `environment` situada en la raiz de la carpeta de la aplicacion. Para ello ejecutaremos:

Los archivos a crear se llamaran, `environment.prod.ts` y `environment.local.ts`. Estos archvios guardaran valores distintos para su ambiente de las variables definidas en `index.ts`.

Teniendo en `environment.prod.ts` lo siguiente:

```TypeScript
export const {
  vidlyApi: 'http://localhost:9000'
}
```

Y en `environment.local.ts` lo siguiente:

```TypeScript
export const {
  vidlyApi: 'https://localhost:7106'
}
```

Para utilizar esta libreria debemos actualizar la seccion de `scripts` de este mismo archivo para que utilice diferentes ambientes cuando ejecute y buildee la aplicacion. Dejando esta seccion de la siguiente manera:

```JSON
"scripts": {
    "ng": "ng",
    "start:local": "env-cmd -f .env.local ng serve",
    "start:prod": "env-cmd -f .env.prod ng serve",
    "build:prod": "env-cmd -f .env.prod ng build",
    "watch": "ng build --watch --configuration development"
  },
```

Donde:

- `start:local`: es el comando a utilizar para correr la aplicacion usando el ambiente `.env.local`
- `start:prod`: es el comando a utilizar para correr la aplicacion usando el ambiente `.env.prod`
- `build:prod`: es el comando a utilizar para compilar la aplicacion usando el ambiente `.env.prod`

Como ultimo paso, para que estos comandos funcionen necesitamos crear dichos archivos en la raiz del directorio de la aplicacion.

El archivo `.env.local` quedaria asi:

```
  vidlyApi=https://localhost:7087
```

Donde este archivo apunta al host y puerto que tenemos en `launchSettings.json` de nuestra api.

El archivo `.env.prod` quedaria asi:

```
  vidlyApi=http://localhost:9000
```

Donde este archivo apunta al host y puerto de nuestra api deployada en produccion.

Estos archivos especificos de los ambientes a utilizar no se deben de commitear, es por eso que se debe actualizar el `.gitignore` agregando:

```
.env.prod
.env.local
```

Para que otro desarrollador pueda crear sus propios archivos de ambiente, es necesario indicar que variables tiene que declarar, para ello debemos crear el archivo `.env` que si se commiteara, y debe tener declarada las variables a utilizar en los diferentes archivos de ambientes.

Teniendo el `.env` asi:

```
vidlyApi=https://localhost:5000
```

Una vez terminadas las declaraciones y configuraciones, es momento de utilizarlo dentro de la aplicacion. Para ello debemos modificar el archivo `environment.ts` el cual es quien tiene encapsulado las variables de ambiente a utilizar dentro de la aplicacion. Gracias a esta decision, evitamos modificar en varias partes de la aplicacion.

Dejando `environment.ts` de la siguiente manera:

```TypeScript
export const environment = {
  vidlyApi: process.env['VIDLY_API'] ?? 'https://localhost:7087',
};
```

Esto significa que tomara el valor de la variable `VIDLY_API` y en caso de encontrar un valor seteara ese, en caso de que sea vacio o null seteara `https://localhost:7087` que es el por defecto.

Previamente a correr la aplicacion, necesitamos instalar `@types/node` para hacer uso de `process`. Para ello ejecutaremos:

```CMD
npm install --save-dev @types/node
```

Que instalara la libreria [`@types/node`](https://www.npmjs.com/package/@types/node) en la seccion de desarrollo en `package.json`.

<p align="center">
<img src="./images/image-13.png">
</p>
<p align="center">
[package.json con @types/node]
</p>

Una vez que este instalado `@types/node` debemos actualizar nuestro `tsconfig.app.json` para que no de errores de compilacion. La property a modificar es `types`, dejando nuestro `tsconfig.app.json` de la siguiente manera:

```JSON
/* To learn more about this file see: https://angular.io/config/tsconfig. */
{
  "extends": "./tsconfig.json",
  "compilerOptions": {
    "outDir": "./out-tsc/app",
    "types": ["node"]
  },
  "files": [
    "src/main.ts"
  ],
  "include": [
    "src/**/*.d.ts"
  ]
}
```
