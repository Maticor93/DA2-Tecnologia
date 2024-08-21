# Creacion de un PullRequest - PR

Un pull request (PR) en GitHub es un mecanismo para los desarrolladores de proponer cambios al codigo fuente. Le permite a los desarrolladores notificarle a los miembros del equipo que se completo una feature o el arreglo de un bug y el codigo asociado a esos cambios esta listo para ser revisado y potencialmente para mergear en la rama del ambiente correspondiente. En el PR se encuentra mucha informacion sobre los cambios a introducir como poder ver las diferencias de los archivos manipulados (agregaciones, modificaciones y eliminaciones).

>[!NOTE]
>- Existen dos elementos fundamentales, lo que se llama source branch (la rama que contiene los cambios) y la target branch (la rama a donde se quiere mergear los cambios).
>- Una vez creado el PR, se pueden seguir agregando commits a la head branch (rama con los cambios) y este automaticamente se vera actualizado.

## Draft PR
Cuando uno crea un PR, puede decir en ese momento si esta listo para ser revisado por el resto del equipo o si es un trabajo en proceso (WIP). Los draft PRs no pueden ser mergeados, y los dueños no tienen permitido solicitar la revision de los mismos. Cuando uno considera que el trabajo en la source branch esta terminado y listo para ser revisado, se puede marcar el draft PR como ready for review. Hacer un PR ready for review solicitara revision a cualquier colaborador del repositorio. Asi como se puede convertir un PR de draft a ready for review, se puede realizar la accion inversa.


## Creacion de un PR

La web de github detecta cuales ramas estan mas avanzadas que la default branch, y en el inicio sugieren crear un PR desde aquellas ramas.

