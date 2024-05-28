# Descargar Angular

Angular requiere una version LTS de Node. Para confirmar la version de `node.js` debemos ejectuar el siguiente comando en una terminal:

```CMD
node --version
```

La version a utilizar debe ser la `20.13.1`, en caso de no tener esta version, seguir los siguientes pasos para actualizarla o instalarla en caso de no tener ninguna version instalada.

## Descargar Node.js

### Con nvm en windows

Antes de realizar la instalacion de nvm, es necesario desinstalar cualquier version de node que este instalada en la maquina para evitar posibles problemas.

Con nvm (node version manager) podremos tener mas de una version de Node en la maquina. Para ello tenemos que ir a [nvm](https://github.com/coreybutler/nvm-windows?tab=readme-ov-file) y descargamos el [nvm-setup.zip](https://github.com/coreybutler/nvm-windows/releases) de la ultima version. Lo instalamos y ya podremos usar los comandos:

```CMD
nvm install <<version de node a instalar>>
nvm use <<version de node instalada>>
```

Para listar todas las versiones de node gestionadas por nvm, ejectuar:

```CMD
nvm list
```

### Con fnm en windows o nvm en macOS

Tambien podemos seguir los pasos de [Node.js](https://nodejs.org/en/download/package-manager) y seleccionamos la version anteriormente dicha y la procedemos a descargar con `fnm` en caso de estar trabajando con Windows o con `nvm` en caso de estar con macOS.

### Un instalador de una version especifica

Tambien podemos descargar una version de Node.js desde un [installer](https://nodejs.org/en/download/prebuilt-installer).

### Verificar version de Node.js y npm

Una vez terminada la instalacion ejectuar:

```CMD
node --version
```

La salida esperada debe ser: `20.13.1`

y luego

```CMD
npm --version
```

La salida esperada debe ser: `10.5.2`

Para corroborar la version instalada y que se esta usando.

## Instalar Angular CLI

Con `node.js` y `npm` instalado, el siguiente paso es instalar [Angular CLI](https://v17.angular.io/cli), la cual es una herramienta de interfaz de comandos para inicializar, desarrollar y mantener aplicaciones de Angular directamente desde una terminal.

Desde una terminal ejectuar el siguiente comando:

```CMD
npm install -g @angular/cli
```

Para chequear si quedo instalado ejectuar:

```CMD
ng version
```

Teniendo como resultado:

<p align="center">
<img src="./images/image-13.png"/>
</p>
<p align="center">
[Version de Angular CLI]
</p>

Es importante que la version de `Angular CLI` sea la `18.0.1` para la version de `node` `20.13.1` y `npm` `10.5.2`.

En caso de que tengamos esa version de node pero otra version de angular-cli, ejectuar lo siguiente:

```CMD
npm uninstall -g @angular/cli
```

Y volver a instalar nuevamente Angular CLI.

Si la version no sufrio alguna variacion, dirijirse al directorio donde tienen instalado npm:

```CMD
C://Users/<<nombre de usuario>>/AppData/Roaming/npm
```

Ahi encontraran 3 archivos con el nombre `ng`, eliminarlos.

Volver a instalar nuevamente Angular CLI.

## Descargar un IDE

Se puede utilizar cualquier editor de texto preferido, sin embargo, es altamente recomendado que se descarge [Visual Studio Code](https://code.visualstudio.com/).

Para mejorar la experiencia de desarrollo es recomendado instalar los siguientes plugins en Visual Studio Code:

- [Angular Language Service](https://marketplace.visualstudio.com/items?itemName=Angular.ng-template)

## Lecturas recomendadas

- [Primera aplicacion en Angular](https://v17.angular.io/tutorial/first-app)
