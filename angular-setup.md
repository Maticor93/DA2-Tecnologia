# Descargar Angular

Angular requiere una version LTS de Node. Para confirmar la version de `node.js` debemos ejectuar el siguiente comando en una terminal:

```CMD
node --version
```

La version a utilizar debe ser la `20.13.1`, en caso de no tener esta version, seguir los siguientes pasos para actualizarla o instalarla en caso de no tener ninguna version instalada.

## Descargar Node.js

## Con nvm en windows
En caso de querer tener mas de una version de Node, debemos de descargar un manejador de versiones de node, para windows podemos descargar [nvm](https://4geeks.com/how-to/nvm-install-windows) el cual nos permitira tener mas de una version de node en el sistema operativo e ir intercalandolo.

## Con fnm en windows o nvm en macOS
Tambien podemos seguir los pasos de [Node.js](https://nodejs.org/en/download/package-manager) y seleccionamos la version anteriormente dicha y la procedemos a descargar con `fnm` en caso de estar trabajando con Windows o con `nvm` en caso de estar con macOS.

## Un instalador de una version especifica
Tambien podemos descargar una version de Node.js desde un [installer](https://nodejs.org/en/download/prebuilt-installer).

Una vez terminada la instalacion ejectuar nuevamente:

```CMD
node --version
```

Para corroborar la version instalada y que se esta usando.

## Instalar Angular CLI

Con `node.js` y `npm` instalado, el siguiente paso es instalar [Angular CLI](https://v17.angular.io/cli), la cual es una herramienta de interfaz de comandos para inicializar, desarrollar y mantener aplicaciones de Angular directamente desde una terminal.

Desde una terminal ejectuar el siguiente comando:

```CMD
npm install -g @angular/cli
```

Para chequear si quedo instalado ejectuar:

```CMD
ng --help
```

## Descargar un IDE

Se puede utilizar cualquier editor de texto preferido, sin embargo, es altamente recomendado que se descarge [Visual Studio Code](https://code.visualstudio.com/).

Para mejorar la experiencia de desarrollo es recomendado instalar los siguientes plugins en Visual Studio Code:

- [Angular Language Service](https://marketplace.visualstudio.com/items?itemName=Angular.ng-template)

## Lecturas recomendadas

- [Primera aplicacion en Angular](https://v17.angular.io/tutorial/first-app)

