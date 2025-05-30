# EIII_COVID: Survival Horror en el MIC

![Tráiler del Juego]([RUTA_AL_GIF_TRAILER])

## Introducción

**EIII_COVID** es un emocionante juego *Survival Horror* desarrollado en Unity como Trabajo Final de Carrera, calificado con una puntuación perfecta de 10/10. Sumérgete en una atmósfera de tensión y misterio mientras exploras el Módulo de Investigación Cibernética (MIC), un entorno real modelado en 3D, enfrentándote a una mutación viral terrorífica.

## Trama

En los convulsos tiempos de la pandemia de COVID-19, el MIC, un centro de investigación adyacente a la facultad de ingenierías de la Universidad, se habilita para estudiar posibles vacunas. Los experimentos se realizan con voluntarios, pero algo sale terriblemente mal. Una mutación del virus, mucho más agresiva e impredecible, se desata, convirtiendo el centro en una trampa mortal. Como jugador, deberás adentrarte en sus instalaciones, descubrir la verdad detrás del desastre y luchar por sobrevivir.

## Características Principales

*   **Survival Horror Intenso:** Atmósfera opresiva, recursos limitados y enemigos mutantes que pondrán a prueba tus nervios.
*   **Modo Historia Inmersivo:** Sigue una intrigante cadena de misiones, gestiona el estado de tu personaje y desvela los secretos del MIC.
*   **Múltiples Modos Desafío:** Pon a prueba tus habilidades en tres niveles de dificultad (Fácil, Medio, Difícil) una vez completada la historia principal o como alternativa rápida de juego.
*   **Entorno Realista:** Explora una recreación fiel del [Módulo de Investigación Cibernética (MIC)](https://maps.app.goo.gl/ETBo1set8XJZKfSr7), basado en su ubicación y estructura real.
*   **Gráficos 3D Detallados:** Sumérgete en un entorno visualmente cuidado que potencia la ambientación de terror.
*   **Rica Galería de Personajes:** Interactúa o enfréntate a una variedad de personajes, desde científicos y personal de seguridad hasta pacientes y mutaciones hostiles.

## Vídeo Completo del Modo Historia

Si quieres ver un recorrido completo del modo historia, puedes encontrarlo aquí:
[Ver Gameplay Completo del Modo Historia]([RUTA_AL_VIDEO_TRAILER])

## Reconocimiento Académico

Este proyecto fue desarrollado como Trabajo Final de Carrera para optar al título de Ingeniero/a en [Tu Titulación Aquí], obteniendo la máxima calificación (10/10).

Puedes consultar el documento completo del TFG aquí:
[Descargar TFG (PDF)]([RUTA_AL_TFG_PDF])

## Detalles Técnicos

*   **Motor de Juego:** Unity 3D
*   **Lenguaje de Programación:** C#
*   **Sistemas Clave Implementados:**
    *   Gestor de Juego Avanzado (`GameManager.cs`): Controla los estados del juego, modos (historia/desafío), progresión y eventos principales.
    *   Sistema de Diálogos Dinámico (`DialogueManager.cs`, `DialogueTrigger.cs`): Permite interacciones narrativas con NPCs.
    *   Sistema de Misiones Jerárquico (`QuestGiver.cs`, `WhenComplete.cs`): Guía al jugador a través de la trama con objetivos claros.
    *   Mecánicas de Interacción Específicas: Como el uso de jeringuillas (`syringe.cs`), gestión de dosis de vacunas (`VacuneDose.cs`), y resolución de puzles ambientales (`CollElectricity.cs`).
    *   IA para Enemigos y NPCs: Comportamientos diferenciados para los distintos tipos de personajes (`Enemies/`, `Scientists/`, `Patients/`).
    *   Gestión de Personajes y Cámara: Selección de personaje (`ChooseCharacter.cs`), carga (`LoadCharacter.cs`) y seguimiento de cámara inteligente (`CameraFollow.cs`, `CameraCollision.cs`).
    *   Interfaz de Usuario y Menús: Navegación fluida entre menús (`MenuController.cs`), sistema de pausa (`pause.cs`) y transiciones (`TransicionMenu.cs`).
    *   Sistemas de Desafío Temporizados (`CountDownTimer.cs`, `CountDownTimerChallenge.cs`).

## Diseño del Juego

*   **Narrativa Envolvente:** La historia se desarrolla a través de misiones y diálogos, manteniendo al jugador enganchado.
*   **Exploración y Puzles:** El jugador debe explorar el detallado entorno del MIC, resolver puzles y encontrar recursos para sobrevivir.
*   **Atmósfera de Terror:** Uso de iluminación (`FlickerLight.cs`), sonidos (`HorrorSounds.cs`) y diseño de niveles para crear una experiencia de terror constante.
*   **Progresión y Descubrimiento:** A medida que el jugador avanza, descubre más sobre el origen de la mutación y los eventos que llevaron al desastre.

## El Entorno: MIC (Módulo de Investigación Cibernética)

El juego se desarrolla en una recreación del **Módulo de Investigación Cibernética (MIC)**, un edificio real. Puedes ver su ubicación aquí:
[Ver MIC en Google Maps](https://maps.app.goo.gl/ETBo1set8XJZKfSr7)

## Cómo Jugar / Contribuir

El juego pronto estará disponible para jugarlo en formato WebGL desde itch.io

1.  Clona el repositorio: `git clone https://github.com/ivancastroprojects/game-covid-survival.git`
2.  Abre el proyecto con Unity Hub (se recomienda la versión X.Y.Z de Unity o superior).
3.  ¡Explora el código, los assets y diviértete!

## Licencia MIT
---
