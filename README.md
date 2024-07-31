# Sistema de Votación

<p align="center">
  <img src="https://github.com/user-attachments/assets/32f22ebb-ec4d-4610-af9e-e1f2dc161bce" alt="vote" />
</p>

# Introducción

<p>Este sistema fue creado para gestionar un proceso de votación, asegurando que cada usuario pueda votar una única vez.</p>

## Índice
* [1. Diagrama de la Base de Datos](#1-diagrama-de-la-base-de-datos)
* [2. Diagrama de Secuencia](#2-diagrama-de-secuencia)
* [3. Estructura del Proyecto](#3-estructura-del-proyecto)
  * [Arquitectura en Capas](#arquitectura-en-capas)
  * [Identity](#identity)
  * [Envío de Correos](#envío-de-correos)
  * [Web APIs](#web-apis)
  * [Listado de Votaciones](#listado-de-votaciones)
* [4. Módulos](#4-módulos)
  * [Gestión de Candidatos](#gestión-de-candidatos)
  * [Autenticación](#autenticación)

## 1. Diagrama de la Base de Datos
<p> A continuación se muestra el diagrama de la base de datos que respalda la funcionalidad del sistema:</p>

![Diagrama de la Base de Datos](https://github.com/user-attachments/assets/bf298c2a-76e2-4d60-8123-51ce387cd060)

## 2. Diagrama de Secuencia
<p>El diagrama de secuencia ilustra el flujo de interacciones durante el proceso de votación:</p>

![Diagrama de Secuencia](https://github.com/user-attachments/assets/05ad4c6d-50fc-4e84-997d-b5158224cd29)

## 3. Estructura del Proyecto

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

## 4. Módulos

<p>El sistema está dividido en módulos que manejan distintas funcionalidades, facilitando la extensión y mantenimiento:</p>

![Módulos](https://github.com/hdbr00/VotingSystem/assets/119827170/b429c306-a267-43fe-be72-f812ce0fd64e)

### Gestión de Candidatos
<p> Los candidatos son gestionados a través de un módulo específico:</p>

![Gestión de Candidatos](https://github.com/hdbr00/VotingSystem/assets/119827170/c2a4df5a-1992-47ad-bde4-816125fff9b7)

### Autenticación
<p> El proceso de autenticación por facebook:</p>

![Autenticación](https://github.com/hdbr00/VotingSystem/assets/119827170/60dac356-9906-4922-879c-007457f050db)

