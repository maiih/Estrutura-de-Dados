using System;
using System.Collections.Generic;

// Enumeração para os tipos de travessia
public enum TraversalEnum
{
    PREORDER,
    INORDER,
    POSTORDER
}

// Classe que representa um nó genérico de árvore
public class TreeNode<T>
{
    public T Data { get; set; }
    public TreeNode<T> Parent { get; set; }
    public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();

    public int GetHeight()
    {
        int height = 1;
        TreeNode<T> current = this;
        while (current.Parent != null)
        {
            height++;
            current = current.Parent;
        }
        return height;
    }
}

// Classe específica para nós de árvores binárias
public class BinaryTreeNode<T> : TreeNode<T>
{
    public BinaryTreeNode() => Children = new List<TreeNode<T>>() { null, null };

    public BinaryTreeNode(T value) : this()
    {
        Data = value;
    }

    public BinaryTreeNode<T> Left
    {
        get { return (BinaryTreeNode<T>)Children[0]; }
        set { Children[0] = value; }
    }

    public BinaryTreeNode<T> Right
    {
        get { return (BinaryTreeNode<T>)Children[1]; }
        set { Children[1] = value; }
    }
}

// Classe que representa a árvore binária completa
public class BinaryTree<T> where T : IComparable<T>
{
    public BinaryTreeNode<T> Root { get; set; }
    public int Count { get; set; }

    // Método de inserção público
    public void Insert(T value)
    {
        // Se a árvore estiver vazia, o novo nó se torna a raiz
        if (Root == null)
        {
            Root = new BinaryTreeNode<T>(value);
            Count++;
        }
        else
        {
            // Caso contrário, chama o método auxiliar recursivo para encontrar a posição correta
            InsertNode(Root, value);
        }
    }

    // Método de inserção privado e recursivo
    private void InsertNode(BinaryTreeNode<T> node, T value)
    {
        // Se o novo valor for menor que o valor do nó atual
        if (value.CompareTo(node.Data) < 0)
        {
            // Se não houver filho esquerdo, insere o novo nó aqui
            if (node.Left == null)
            {
                node.Left = new BinaryTreeNode<T>(value);
                node.Left.Parent = node;
                Count++;
            }
            else
            {
                // Caso contrário, continua a busca no filho esquerdo
                InsertNode(node.Left, value);
            }
        }
        // Se o novo valor for maior ou igual ao valor do nó atual
        else
        {
            // Se não houver filho direito, insere o novo nó aqui
            if (node.Right == null)
            {
                node.Right = new BinaryTreeNode<T>(value);
                node.Right.Parent = node;
                Count++;
            }
            else
            {
                // Caso contrário, continua a busca no filho direito
                InsertNode(node.Right, value);
            }
        }
    }

    // Métodos de travessia privados e recursivos
    private void TraversePreOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            result.Add(node);
            TraversePreOrder(node.Left, result);
            TraversePreOrder(node.Right, result);
        }
    }

    private void TraverseInOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            TraverseInOrder(node.Left, result);
            result.Add(node);
            TraverseInOrder(node.Right, result);
        }
    }

    private void TraversePostOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            TraversePostOrder(node.Left, result);
            TraversePostOrder(node.Right, result);
            result.Add(node);
        }
    }

    // Método público para iniciar a travessia
    public List<BinaryTreeNode<T>> Traverse(TraversalEnum mode)
    {
        List<BinaryTreeNode<T>> nodes = new List<BinaryTreeNode<T>>();
        switch (mode)
        {
            case TraversalEnum.PREORDER:
                TraversePreOrder(Root, nodes);
                break;
            case TraversalEnum.INORDER:
                TraverseInOrder(Root, nodes);
                break;
            case TraversalEnum.POSTORDER:
                TraversePostOrder(Root, nodes);
                break;
        }
        return nodes;
    }

    // Método público para calcular a altura da árvore
    public int GetHeight()
    {
        int height = 0;
        if (Root != null)
        {
            foreach (BinaryTreeNode<T> node in Traverse(TraversalEnum.PREORDER))
            {
                height = Math.Max(height, node.GetHeight());
            }
        }
        return height;
    }
}

// Classe principal para testar a implementação
class Program
{
    static void Main(string[] args)
    {
        // Instancia uma nova Árvore Binária de Busca para inteiros
        BinaryTree<int> bst = new BinaryTree<int>();

        // Valores a serem inseridos
        int[] values = { 10, 5, 20, 3, 7, 15, 30 };

        Console.WriteLine("Inserindo valores: 10, 5, 20, 3, 7, 15, 30\n");

        // Insere cada valor na árvore
        foreach (var value in values)
        {
            bst.Insert(value);
        }

        // Mostra a travessia em Pré-Ordem
        Console.WriteLine("Travessia em Pré-Ordem:");
        List<BinaryTreeNode<int>> preOrderResult = bst.Traverse(TraversalEnum.PREORDER);
        foreach (var node in preOrderResult)
        {
            Console.Write(node.Data + " ");
        }
        Console.WriteLine("\n");

        // Mostra a travessia Em-Ordem
        Console.WriteLine("Travessia Em-Ordem:");
        List<BinaryTreeNode<int>> inOrderResult = bst.Traverse(TraversalEnum.INORDER);
        foreach (var node in inOrderResult)
        {
            Console.Write(node.Data + " ");
        }
        Console.WriteLine("\n");

        // Mostra a travessia em Pós-Ordem
        Console.WriteLine("Travessia em Pós-Ordem:");
        List<BinaryTreeNode<int>> postOrderResult = bst.Traverse(TraversalEnum.POSTORDER);
        foreach (var node in postOrderResult)
        {
            Console.Write(node.Data + " ");
        }
        Console.WriteLine("\n");

    }
}