// -- ТЕСТЫ --
// https://contest.yandex.ru/contest/24810/run-report/65696196/
// 
// -- ПРИНЦИП РАБОТЫ -- 
// Для удаления вершины у которой есть потомки решил выбирать самую правую вершину в левом потомке.
// 
// -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
// Функция удаления работает за O(2H-1), где H – высота дерева,
// так сначала находится элемент, который нужно удалить для чего нужно H операций,
// затем в левом потомке этого элемента находится самый правый элемент, для чего нужно сделать H-1 операций.
// Итого сложность O(H).
//
// -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
// Дополнительной памяти не требуется
//
// -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --
// При удалении элемента возможно пять ситуаций,
// 1. когда в дереве нет нужного ключа, тогда мы возвращаем исходную вершину
// 2. когда мы удаляем корень дерева из одного элемента, тогда мы возвращаем null, так как в дереве больше нет элементов
// 3. когда мы удаляем лист дерева, тогда получаем дерево без одного листа
// 4. когда мы удаляем вершину и получаем два дерева в результате
// 5. когда мы удаляем вершину и получаем три дерева в результате
// 
// В последгних двух ситуациях (4 и 5) получаем несколько деревьев,
// чтобы восстановить дерево, мы выбираем элемент из дочерних, который станет новой вершиной дерева,
// по свойствам бинарной кучи нам подходит либо самый правый элемент левого потомка, либо самый левый элемент правого.
// В своём решении я пошёл первым путём.
//
// Остальное тут: https://practicum.yandex.ru/learn/algorithms/courses/7f101a83-9539-4599-b6e8-8645c3f31fad/sprints/21363/topics/e7dbf42a-fd5a-434b-990d-9cfe0e3a10c8/lessons/03eb9b46-4c74-43b4-8d00-a125aeed47bf/

using System;

// закомментируйте перед отправкой
public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class Solution
{
    private static Node RemoveDeepestRight(Node root)
    {
        var right = root.Right;
        if (right == null)
        {
            return root;
        }

        if (right.Left == null && right.Right == null)
        {
            root.Right = null;
            return right;
        }

        if (right.Left != null && right.Right == null)
        {
            root.Right = right.Left;
            right.Left = null;
            return right;
        }

        return RemoveDeepestRight(right);
    }

    public static Node Remove(Node root, int key)
    {
        if (root == null)
        {
            return null;
        }

        if (key == root.Value)
        {
            if (root.Left != null)
            {
                var deepestRight = RemoveDeepestRight(root.Left);
                if (deepestRight != root.Left) deepestRight.Left = root.Left;
                deepestRight.Right = root.Right;
                return deepestRight;
            }

            return root.Right;
        }

        if (key > root.Value)
        {
            if (root.Right != null)
            {
                root.Right = Remove(root.Right, key);
            }

            return root;
        }
        else
        {
            if (root.Left != null)
            {
                root.Left = Remove(root.Left, key);
            }

            return root;
        }
    }
}