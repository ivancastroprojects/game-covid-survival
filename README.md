# EIII_COVID: Survival Horror at the MIC 🧟🔬

[![Game Trailer](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Videos/GIFTrailer.gif)](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Videos/VideoTrailer.mp4)

*Click the image to watch the full trailer or [see the complete story mode gameplay here](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Videos/VideoTrailer.mp4)!*

## 🚀 Introduction

**EIII_COVID** is a chilling *Survival Horror* game developed in **Unity 3D** with **C#**. This project is not just a game, but the culmination of a **Final Degree Project**, awarded a **perfect score of 10/10**. Get ready for a deep dive into the Cybernetic Research Module (MIC), a real university environment meticulously recreated in 3D, now turned into the epicenter of a terrifying viral mutation.

![MIC Lobby](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Images/Pic_Lobby.png)

*The Cybernetic Research Module (MIC) – Your nightmare begins here.*

## 📜 Story & Setting

Set during the turbulent days of the **COVID-19** pandemic, the **[Cybernetic Research Module (MIC)](https://maps.app.goo.gl/ETBo1set8XJZKfSr7)**, a real building next to the School of Engineering at the University of León, Spain, has been repurposed for urgent vaccine research. Brave volunteers participate in clinical trials. However, hope turns to horror when an experiment goes catastrophically wrong, unleashing an **extremely aggressive viral mutation**.

As the player, you are trapped in this biological nightmare. Your mission is to navigate the dangerous MIC facilities, face mutant horrors, uncover the truth behind the outbreak, and, above all, fight for your survival.

## 🎮 Game Features

* **Intense Survival Horror:** Oppressive atmosphere, limited resources, and mutant enemies that will test your nerves.
* **Immersive Story Mode:** Follow an exciting quest chain (`Quest.cs`, `QuestGoal.cs`) that guides you through the dark plot, revealing the secrets of the MIC step by step.
* **Multiple Challenge Modes:** Test your skills in three difficulty levels (Easy, Medium, Hard) after completing the main story or as a quick alternative.
* **Realistic Environment:** Explore a faithful recreation of the [Cybernetic Research Module (MIC)](https://maps.app.goo.gl/ETBo1set8XJZKfSr7), based on its real location and structure.
* **Detailed 3D Graphics:** Immerse yourself in a visually rich environment that enhances the horror atmosphere.
* **Diverse Cast of Characters:** Interact with or face a variety of characters, from scientists and security staff to patients and hostile mutations.
* **Player State Management:** Manage your health, inventory, and other vital stats to survive the challenges.
* **Exploration & Puzzles:** Discover clues, solve environmental puzzles (`CollElectricity.cs`), and find the resources needed to progress.
* **Environment & Character Interaction:** Engage in dialogue with survivors (`DialogueManager.cs`, `DialogueTrigger.cs`) and face a variety of enemies (`Enemies/`, `Scientists/`, `Patients/`).

![Story Mode Gameplay](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Images/Pic_StoryModeGameplay.png)

*Investigating the laboratories in Story Mode.*

### Intense Challenge Modes
Test your survival skills in **three difficulty levels**:
* **Easy:** A balanced challenge to get familiar with the mechanics.
* **Medium:** Tougher enemies and scarcer resources.
* **Hard:** An extreme test of your skills and nerves—only for the bravest!

![Challenge Modes](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Images/Pic_ChallengeModesGameplay.png)

*Face hordes of mutants in the different Challenge Modes.*

### Game Design & Mechanics
* **Oppressive Atmosphere:** Dynamic lighting and flicker effects (`FlickerLight.cs`), along with horror ambient sounds (`HorrorSounds.cs`), create a truly immersive experience.
* **Survival Arsenal:** Use syringes (`syringe.cs`) to heal or attack, manage vaccine doses (`VacuneDose.cs`), and utilize other key items for survival.
* **Detailed Characters:** The game features a variety of character models (`MainCharacter/`, `MainScientist/`, `SavedPersons/`, etc.), including a main character based on a 3D scan of the developer himself.

![3D Scan of the Developer for the Main Character](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Images/Pic_MeScanned3D.png)

*3D scanning and Blender modeling process of Iván Castro Martínez (myself) for the main character. Point cloud studies were conducted to map the face, right in the MIC where the story takes place.*

![In-Game Items](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/Assets/Items/Images/Pic_ItemsInGameAvailable.png)

*Key items you will find and need to survive.*

## 🎓 Academic Recognition & Documentation

This project was my **Final Degree Project** to obtain the title of Computer Engineer at the University of León, Spain. [https://www.unileon.es/estudiantes/oferta-academica/grados/grado-en-ingenieria-informatica]

My **Final Degree Project** was titled **MIC OUT OF CONTROL**, and it received a **perfect score of 10/10**.

For those interested in technical details, the development process, and the research behind the game, you can check out the full thesis document:

[📜 Download Full Thesis (PDF)](https://raw.githubusercontent.com/ivancastroprojects/game-covid-survival/main/tfg.pdf)

## 🛠️ Technical Details

* **Game Engine:** Unity 3D
* **Programming Language:** C#
* **3D Modeling & Assets:** Blender, among other tools.
* **Project Management & Version Control:** Git, GitHub, Git LFS.
* **Key Scripts:**
    * `GameManager.cs`: Main orchestrator for game states, modes, UI.
    * `QuestGiver.cs`, `Quest.cs`, `QuestGoal.cs`: Quest system.
    * `DialogueManager.cs`, `DialogueTrigger.cs`: Dialogue system.
    * `syringe.cs`, `VacuneDose.cs`: Healing/attack mechanics.
    * `CountDownTimer.cs`, `CountDownTimerChallenge.cs`: Timers for challenge modes.
    * `CameraFollow.cs`, `CameraCollision.cs`: Camera system.
    * `ChooseCharacter.cs`, `LoadCharacter.cs`: Character selection and loading.

## 🌐 Play EIII_COVID (Coming Soon on WebGL)

Soon, you'll be able to experience the horror right in your browser! I'm working to make **EIII_COVID** playable in **WebGL** format via [itch.io](https://ivanintech.com/projects/game-covid-survival/).

## 📦 How to Contribute or Play Locally

1. **Clone the repository:**
    ```bash
    git clone https://github.com/ivancastroprojects/game-covid-survival.git
    cd game-covid-survival
    ```
2. **Make sure you have Git LFS installed and pull large files:**
    ```bash
    git lfs install
    git lfs pull
    ```
3. **Open the project** with Unity Hub (the project has been updated to Unity 6).
4. Explore the code, assets, and have fun (or get scared)!

## 📄 License

This project is distributed under the **MIT License**. See the `LICENSE` file for more details.

---
