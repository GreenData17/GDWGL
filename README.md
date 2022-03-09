# GDWGL

In this project I tried to recreate some of the Windows Forms controls. (buttons, image, text, ...)

> The project is on break. I encountered some problems, which I don't know how to solve.                                    
> If you you know how to solve it, feel free to the make adjustments and make an pull request. It would help me a lot.

​

Known Problems:
- Input gets called multiple times
- sometimes input can't be read
- KeyUp Doesn't work like expected

 ​

General Features:
- Position
- Size
- Update Override
- Logging into the console
- Key press Event
- Mouse PRess Event

​

#### Console for logs.
![console](https://github.com/GreenData17/GDWGL/blob/main/pictures/Console.png)

Possible log types:
- LOG
- INFO
- WARNING
- ERROR

​

### Currently added controls:
#### Buttons

![Button](https://github.com/GreenData17/GDWGL/blob/main/pictures/Button.png)

Feature:
- Change background Color
- change border Color
- remove border
- set Button Text
- change Butten Text Font
- change Button Text Color (Foreground Color)
- Call a function on Button press

​

#### Texts

![Text](https://github.com/GreenData17/GDWGL/blob/main/pictures/Text.png)

Feature:
- set Text
- change Text Font
- change Text Color (Foreground Color)
- Call a on Button press

​

#### InputField (replacement InputFieldControl)

![InputField](https://github.com/GreenData17/GDWGL/blob/main/pictures/InputField.png)

Feature:
- Change background Color
- Write stuff (but always multiple times per press and no backspace)

​

#### InputFieldControl

![InputFieldControl](https://github.com/GreenData17/GDWGL/blob/main/pictures/InputFieldControl.png)

Feature:
- Everything the normal "System.windows.Forms.TextBox" can.

​

#### InputDebug

![InfoDebug](https://github.com/GreenData17/GDWGL/blob/main/pictures/InputDebug.png)

Feature:
- displays the current pressed mouse button.
- displays the current pressed keyboard key.

​

#### Image
![Image](https://github.com/GreenData17/GDWGL/blob/main/pictures/Image.png)

(default Image if not selected anything)

Feature:
- Displaying a selected Image
