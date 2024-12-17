# **OldPhonePad Simulator**

This project simulates the behavior of an **old phone keypad** using C#. It interprets user input consisting of digits, spaces, backspaces (`*`), and a send key (`#`) to produce the corresponding text output.

---

## **Table of Contents**
- [Overview](#overview)
- [Features](#features)
- [How It Works](#how-it-works)

---

## **Overview**

The OldPhonePad program takes a string of key presses and outputs the text as if typed on an old phone keypad. The keypad supports:
- **Number keys** (`1-9`): Each key cycles through a set of letters.
- **Backspace key** (`*`): Deletes the last character.
- **Send key** (`#`): Marks the end of input.

For example:  
**Input:** `44 33 555 555 666#`  
**Output:** `HELLO`

---

## **Features**
- Simulates old phone keypad typing.
- Handles backspace using `*`.
- Differentiates consecutive characters typed on the same key using spaces.
- Terminates processing with the send key `#`.

---

## **How It Works**

1. **Input Parsing:**  
   The program reads the input string and processes each character.

2. **Key Mapping:**  
   A dictionary (`dialMap`) maps keys (`1-9`) to their respective letters:
   ```csharp
   { '2', "ABC" }, { '3', "DEF" }, ... { '9', "WXYZ" }
