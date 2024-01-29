# sudoku

## Решение судоку с использованием клеточного автомата
 - У каждой клетки в данный момент времени определено состояние - либо это значение ячейки (от 1 до 9), либо состояние 12 - клетка пустая
 - Программа однозначно вычисляет значение клетки по следующему алгоритму
 - Находит пустую ячейку, состояние которой равно s12
 - От выбранной ячейки находит элементы, которые могут распологаться в данной ячейке путем сопоставления с набором цифр от 1 до 9, сначала проход по горизонтали, затем по вертикали, и, наконец, в квадрате 3х3 где находится данная ячейка.
 - На выходе получается три набора, которые в последствии сравниваются, и если нашлось единственное общее число для всех трех наборов, текущая ячейка заполняется.
 - Автомат работает в цикле до тех пор, пока все ячейки не будут заполнены.
 - Код представлен в файле Form1.cs

## Дополнение клеточного автомата
В дополнении к решению судоку в программе есть еще один автомат - муравей, который после решения головоломки собирает числа с поля и несет к себе в муравейник.
Код также в файле Form1.cs.

## Баги и костыли, todo
Муравей не пробегает по всему судоку, заканчивает после того, как прошел около 4/5 клеток.
Добавить деструкторы.
