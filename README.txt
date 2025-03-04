# ImagePuzzleGame

一個簡單的拼圖遊戲，玩家可以通過排列打亂的圖片片段來完成 3x3 拼圖。遊戲包含選擇圖片、製作拼圖、計算移動次數以及顯示遊戲時間等功能。

## 功能
- **圖片選擇**：讓玩家選擇一張圖片並調整大小，以適應拼圖的尺寸。
- **拼圖製作**：自動將選擇的圖片分割為 9 個區塊，隱藏其中一塊並隨機排列其餘部分。
- **移動計算**：計算移動次數及完成拼圖所需的時間。
- **遊戲結束**：當拼圖完成時，鎖定板子狀態，防止進一步移動。
- **重置功能**：玩家可以重置拼圖，使用相同或不同的圖片開始新遊戲。

## 安裝
1. 克隆此倉庫：
    ```bash
    git clone https://github.com/yourusername/ImagePuzzleGame.git
    ```
2. 在您偏好的 IDE（例如 Visual Studio）中打開專案。
3. 編譯並運行應用程式。

## 遊玩方式
1. **選擇圖片**：從文件選擇器中選擇一張圖片作為拼圖。
2. **製作拼圖**：點擊「製作拼圖」按鈕將圖片分割成 9 個區塊。
3. **開始遊戲**：點擊相鄰的區塊將其移動到空白區域。
4. **完成拼圖**：持續移動區塊，直到拼回原始圖片。
5. **查看結果**：完成拼圖後，顯示所需時間和移動次數。

## 評分標準
- 正常讀取圖片 (5%)
- 顯示與隱藏圖片 (5%)
- 將圖片分割成 9 個區塊 (20%)
- 顯示時間和移動步數 (10%)
- 能夠移動拼圖板 (30%)
- 結束遊戲時的結算和鎖定板子狀態 (10%)
- 可以更換圖片進行新遊戲 (10%)
- 其他 (10%)

## 提示
- 建議利用 Bitmap 來分割圖片。
- 圖片建議大小為 270x270 像素。