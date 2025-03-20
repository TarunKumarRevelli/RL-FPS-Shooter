# RL-FPS-Shooter

A Reinforcement Learning-based First-Person Shooter (FPS) game where an AI agent learns to shoot the player based on their actions. Built using **Unity**, **Reinforcement Learning (PPO)**, and **ML-Agents**.

## 📌 Features
- **AI-controlled enemy** that learns to shoot the player.
- **User-controlled movement and shooting**.
- **Reinforcement Learning training pipeline** using PPO.
- **Dynamic obstacles and cover mechanics**.
- **Real-time FPS gameplay** with AI interaction.

## 🚀 Setup Instructions

### **1️⃣ Clone the Repository**
```sh
git clone https://github.com/TarunKumarRevelli/RL-FPS-Shooter.git
cd RL-FPS-Shooter
```

### **2️⃣ Install Dependencies**
- **Unity Hub** (Recommended: Unity 2021 or later)
- **ML-Agents Toolkit** for training the AI agent
- **Python 3.8+** with dependencies:
  ```sh
  pip install mlagents torch numpy matplotlib
  ```

### **3️⃣ Open in Unity**
1. Open **Unity Hub**.
2. Click **Add Project** and select the `RL-FPS-Shooter` folder.
3. Open the project and ensure all assets load properly.

### **4️⃣ Train the AI Agent**
1. Open a terminal inside the project directory.
2. Run:
   ```sh
   mlagents-learn config/trainer_config.yaml --run-id=FPS-Agent --train
   ```
3. The AI will start training using **PPO (Proximal Policy Optimization)** and improve its shooting accuracy.

### **5️⃣ Play the Game**
- Run the Unity scene `FPS_Shooter.unity` to start playing.
- The AI enemy will dynamically learn and adapt based on reinforcement learning.

## 🛠️ Development Guidelines
### **Git Setup & Best Practices**
- **Ignoring unnecessary files**: This project uses a `.gitignore` file to exclude auto-generated Unity files.
- **LFS Issues**: Ensure large files are stored outside Git using [Git LFS](https://git-lfs.github.com/) or cloud storage.
- **Common Git Commands**:
  ```sh
  git pull origin main  # Sync with the latest version
  git add .
  git commit -m "Your commit message"
  git push origin main
  ```

## 📝 Contributors
- **[Tarun Kumar Revelli](https://github.com/TarunKumarRevelli)** - Developer
- **[Saatvik Prabhu](https://github.com/sevenweeks-07)** - Developer

Feel free to contribute and improve this project! 🎯

