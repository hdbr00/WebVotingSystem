# Sistema de Votación

<p align="center">
  <img src="https://github.com/user-attachments/assets/32f22ebb-ec4d-4610-af9e-e1f2dc161bce" alt="vote" />
</p>

## 1. Introducción
<p>Este sistema fue creado con el fin de permitir a los usuarios ejecutar el derecho al voto, facilitando a los grupos con alguna discapacidad y/o con riesgo de salud poder
 ejercer este derecho. Además, cualquier otra persona con algún tipo de inconveniente en el día de las votaciones, podrá hacer el uso del mismo.
</p>


## Índice
* [1. Introducción](#1-introducción)
* [2. Objetivos](#2-objetivos)
* [3. Descripción del Proyecto](#3-descripción-del-proyecto)
* [4. Criterios de éxito](#4-criterios-de-éxito)
* [5. Diagrama de la Base de Datos](#5-diagrama-de-la-base-de-datos)
* [6. Diagrama de Secuencia](#6-diagrama-de-secuencia)
* [7. Estructura del Proyecto](#7-estructura-del-proyecto)
  * [Arquitectura en Capas](#arquitectura-en-capas)
  * [Identity](#identity)
  * [Envío de Correos](#envío-de-correos)
  * [Web APIs](#web-apis)
  * [Listado de Votaciones](#listado-de-votaciones)
* [8. Módulos](#8-módulos)
  * [Gestión de Candidatos](#gestión-de-candidatos)
  * [Autenticación](#autenticación)
* [9. Autor](#9-autor) 



## 2. Objetivos

  - [ ] Habilitar un sistema que facilite el voto.
  - [ ] Permitir el sufragio fuera de Costa Rica.

## 3. Descripción del Proyecto
<p>
  El sistema permite gestionar a los candidatos y generará el conteo de votos al instante de cada uno de ellos. Se utiliza la autenticación en el electorado para que su sufragio sea de manera única. 
</p>


## 4. Criterios de éxito

- [x] Conteo automático de votos.
- [x] Validación único por persona. 
- [x] Creación y carga de candidatos. 
- [x] Creación de usuarios.
- [x] Cierre de sesión después de ejecutar el voto.
- [x] Carga de partidos / equipos.


## 5. Diagrama de la Base de Datos
<p> A continuación se muestra el diagrama de la base de datos que respalda la funcionalidad del sistema:</p>

![Diagrama de la Base de Datos](https://github.com/user-attachments/assets/bf298c2a-76e2-4d60-8123-51ce387cd060)

## 6. Diagrama de Secuencia
<p>El diagrama de secuencia ilustra el flujo de interacciones durante el proceso de votación:</p>

![Diagrama de Secuencia](https://github.com/user-attachments/assets/05ad4c6d-50fc-4e84-997d-b5158224cd29)

## 7. Estructura del Proyecto

### Arquitectura en Capas
<p> El sistema está diseñado utilizando una arquitectura en capas para mejorar la organización y el mantenimiento del código:</p>

![Arquitectura en Capas](https://github.com/hdbr00/VotingSystem/assets/119827170/fa8318a0-d81b-49bb-8c29-55e9660b37db)

### Identity
<p>El módulo de Identity se utiliza para la gestión de usuarios y la autenticación</p>

![Identity](https://github.com/hdbr00/VotingSystem/assets/119827170/97e67733-d0e1-4c1f-81ba-6aa710662091)

### Envío de Correos
<p> Se incluye funcionalidad para el envío de correos electrónicos, utilizada para notificar a los usuarios sobre su votación:</p>

![Envío de Correos](https://github.com/hdbr00/VotingSystem/assets/119827170/0eae8b11-6eb6-4bad-8b09-dc83aba9181a)

### Web APIs
<p> El sistema expone varias Web APIs para permitir la integración con otros sistemas:</p>

![Web APIs](https://github.com/hdbr00/VotingSystem/assets/119827170/c9893df0-f8e2-43a4-bebf-edfce0eaf163)

### Listado de Votaciones
<p>Los usuarios pueden ver una lista de las votaciones disponibles:</p>

![Listado de Votaciones](https://github.com/hdbr00/VotingSystem/assets/119827170/548f0038-2ab2-4b59-b46e-7307bd6b680c)

## 8. Módulos

<p>El sistema está dividido en módulos que manejan distintas funcionalidades, facilitando la extensión y mantenimiento:</p>

![Módulos](https://github.com/hdbr00/VotingSystem/assets/119827170/b429c306-a267-43fe-be72-f812ce0fd64e)

### Gestión de Candidatos
<p> Los candidatos son gestionados a través de un módulo específico:</p>

![Gestión de Candidatos](https://github.com/hdbr00/VotingSystem/assets/119827170/c2a4df5a-1992-47ad-bde4-816125fff9b7)

### Autenticación
<p> El proceso de autenticación por facebook:</p>

![Autenticación](https://github.com/hdbr00/VotingSystem/assets/119827170/60dac356-9906-4922-879c-007457f050db)

## 9. Autor.
[@hdbr00](https://github.com/hdbr00)

