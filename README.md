# EIII_COVID: Survival Horror en el MIC 🧟🔬

[![Tráiler del Juego](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Videos/GIFTrailer.gif)](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Videos/VideoTrailer.mp4)

*Haz clic en la imagen para ver el tráiler completo o [mira el gameplay del modo historia aquí](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Videos/VideoTrailer.mp4)!*

## 🚀 Introducción

**EIII_COVID** es un escalofriante juego *Survival Horror* desarrollado en **Unity 3D** con **C#**. Este proyecto no es solo un juego, sino la culminación de un **Trabajo Final de Carrera**, distinguido con una **calificación sobresaliente de 10/10**. Prepárate para una inmersión profunda en el Módulo de Investigación Cibernética (MIC), un entorno universitario real meticulosamente modelado en 3D, ahora convertido en el epicentro de una aterradora mutación viral.

![Lobby del MIC](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Images/Pic_Lobby.png)
*El Módulo de Investigación Cibernética (MIC) - Tu pesadilla comienza aquí.*

## 📜 Trama y Ambientación

Nos encontramos en los turbulentos días de la pandemia de **COVID-19**. El **[Módulo de Investigación Cibernética (MIC)](https://maps.app.goo.gl/ETBo1set8XJZKfSr7)**, un edificio real situado junto a la facultad de ingenierías de la Universidad (Escuela de Ingenierías Industriales e Informáticas de León, España), ha sido adaptado para la investigación urgente de vacunas. Voluntarios valientes participan en los ensayos clínicos. Sin embargo, la esperanza se torna en horror cuando un experimento sale catastróficamente mal, desatando una **mutación viral extremadamente agresiva**.

Como jugador, te verás atrapado en este infierno biológico. Tu misión será navegar por las peligrosas instalaciones del MIC, enfrentarte a horrores mutantes, desentrañar la verdad detrás del brote y, sobre todo, luchar por tu supervivencia.

## 🎮 Características del Juego

* **Survival Horror Intenso:** Atmósfera opresiva, recursos limitados y enemigos mutantes que pondrán a prueba tus nervios.
* **Modo Historia Inmersivo:** Sigue una emocionante cadena de misiones (`Quest.cs`, `QuestGoal.cs`) que te guiará a través de la oscura trama del juego, revelando los secretos del MIC paso a paso.
* **Múltiples Modos Desafío:** Pon a prueba tus habilidades en tres niveles de dificultad (Fácil, Medio, Difícil) una vez completada la historia principal o como alternativa rápida de juego.
* **Entorno Realista:** Explora una recreación fiel del [Módulo de Investigación Cibernética (MIC)](https://maps.app.goo.gl/ETBo1set8XJZKfSr7), basado en su ubicación y estructura real.
* **Gráficos 3D Detallados:** Sumérgete en un entorno visualmente cuidado que potencia la ambientación de terror.
* **Rica Galería de Personajes:** Interactúa o enfréntate a una variedad de personajes, desde científicos y personal de seguridad hasta pacientes y mutaciones hostiles.
* **Control de Estados del Jugador:** Gestiona tu salud, inventario y otros estados vitales para sobrevivir a los desafíos.
* **Exploración y Puzles:** Descubre pistas, resuelve puzles ambientales (`CollElectricity.cs`) y encuentra los recursos necesarios para avanzar.
* **Interacción con el Entorno y Personajes:** Dialoga con supervivientes (`DialogueManager.cs`, `DialogueTrigger.cs`) y enfréntate a una variedad de enemigos (`Enemies/`, `Scientists/`, `Patients/`).

![Gameplay del Modo Historia](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Images/Pic_StoryModeGameplay.png)
*Investigando los laboratorios en el Modo Historia.*

### Modos Desafío Intensos
Pon a prueba tus habilidades de supervivencia en **tres niveles de dificultad**:
* **Fácil:** Un reto equilibrado para familiarizarte con las mecánicas.
* **Medio:** Los enemigos son más resistentes y los recursos más escasos.
* **Difícil:** Una prueba extrema de tus habilidades y nervios, ¡solo para los más valientes!

![Modos Desafío](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Images/Pic_ChallengeModesGameplay.png)
*Enfréntate a hordas de mutantes en los diferentes Modos Desafío.*

### Diseño de Juego y Mecánicas
* **Atmósfera Opresiva:** Iluminación dinámica y efectos de parpadeo (`FlickerLight.cs`), junto con sonidos de terror ambiental (`HorrorSounds.cs`), crean una experiencia verdaderamente inmersiva.
* **Arsenal de Supervivencia:** Utiliza jeringuillas (`syringe.cs`) para administrar curas o atacar, gestiona dosis de vacunas (`VacuneDose.cs`) y utiliza otros objetos clave para tu supervivencia.
* **Personajes Detallados:** El juego cuenta con una variedad de modelos de personajes (`MainCharacter/`, `MainScientist/`, `SavedPersons/`, etc.), incluyendo un personaje principal basado en un escaneo 3D del propio desarrollador.

![Escaneo 3D del Desarrollador para el Personaje](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Images/Pic_MeScanned3D.png)
*Proceso de escaneo 3D y modelado en Blender de Iván Castro Martínez (yo mismo) para el personaje principal. Se hicieron estudios de nubes de puntos para mapear el rostro, en el mismo centro MIC donde transcurre la historia.*

![Items disponibles en el juego](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Images/Pic_ItemsInGameAvailable.png)
*Objetos clave que encontrarás y necesitarás para sobrevivir.*

## 🎓 Reconocimiento Académico y Documentación

Este proyecto fue mi **Trabajo Final de Carrera** para optar al título de Ingeniero Informático en la Universidad de León, España. [https://www.unileon.es/estudiantes/oferta-academica/grados/grado-en-ingenieria-informatica]

Mi **Título de Trabajo Final de Carrera** fue **MIC OUT OF CONTROL**, y fue calificado con un **10 sobre 10**.

Para aquellos interesados en los detalles técnicos, el proceso de desarrollo y la investigación detrás del juego, pueden consultar el documento completo del TFG:

[📜 Descargar TFG Completo (PDF)](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/tfg.pdf)

## 🛠️ Detalles Técnicos

* **Motor de Juego:** Unity 3D
* **Lenguaje de Programación:** C#
* **Modelado 3D y Assets:** Blender, entre otras herramientas.
* **Gestión de Proyecto y Control de Versiones:** Git, GitHub, Git LFS.
* **Scripts Clave Destacados:**
    * `GameManager.cs`: Orquestador principal del juego, estados, modos, UI.
    * `QuestGiver.cs`, `Quest.cs`, `QuestGoal.cs`: Sistema de misiones.
    * `DialogueManager.cs`, `DialogueTrigger.cs`: Sistema de diálogos.
    * `syringe.cs`, `VacuneDose.cs`: Mecánicas de curación/ataque.
    * `CountDownTimer.cs`, `CountDownTimerChallenge.cs`: Temporizadores para los modos desafío.
    * `CameraFollow.cs`, `CameraCollision.cs`: Sistema de cámara.
    * `ChooseCharacter.cs`, `LoadCharacter.cs`: Selección y carga de personajes.

## 🌐 Juega EIII_COVID (Próximamente en WebGL)

¡Pronto podrás experimentar el terror directamente en tu navegador! Estoy trabajando para hacer **EIII_COVID** jugable en formato **WebGL** a través de [itch.io](https://ivanintech.com/projects/game-covid-survival/).

## 📦 Cómo Contribuir o Probar Localmente

1. **Clona el repositorio:**
    ```bash
    git clone https://github.com/ivancastroprojects/game-covid-survival.git
    cd game-covid-survival
    ```
2. **Asegúrate de tener Git LFS instalado y obtén los archivos grandes:**
    ```bash
    git lfs install
    git lfs pull
    ```
3. **Abre el proyecto** con Unity Hub (se ha actualizado el proyecto a Unity 6).
4. ¡Explora el código, los assets y diviértete (o asústate)!

## 📄 Licencia

Este proyecto se distribuye bajo la **Licencia MIT**. Consulta el archivo `LICENSE` para más detalles.

---
