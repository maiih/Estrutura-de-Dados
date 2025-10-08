using System;
using System.Collections.Generic;

// Enumeração para tipos de travessia (ordem de percorrer os nós da árvore)
public enum TraversalEnum
{
    PREORDER,   // Pré-Ordem
    INORDER,    // Em-Ordem
    POSTORDER   // Pós-Ordem
}

// Classe genérica de nó (pode servir para árvores em geral)
public class TreeNode<T>
{
    public T Data { get; set; }                      // Valor armazenado no nó
    public TreeNode<T> Parent { get; set; }          // Referência para o nó pai
    public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>(); // Lista de filhos

    // Método que calcula a altura do nó (distância até a raiz)
    public int GetHeight()
    {
        int height = 1;             // Altura mínima é 1 (o próprio nó)
        TreeNode<T> current = this; // Começa do nó atual
        while (current.Parent != null) // Enquanto não chegar à raiz
        {
            height++;               // Soma 1 a cada nível subindo
            current = current.Parent;
        }
        return height;
    }
}

// Nó específico para árvore binária (herda de TreeNode<T>)
public class BinaryTreeNode<T> : TreeNode<T>
{
    // Construtor: define 2 filhos fixos (esquerda e direita)
    public BinaryTreeNode() => Children = new List<TreeNode<T>>() { null, null };

    // Propriedade para acessar o filho da esquerda
    public BinaryTreeNode<T> Left
    {
        get { return (BinaryTreeNode<T>)Children[0]; }
        set { Children[0] = value; }
    }

    // Propriedade para acessar o filho da direita
    public BinaryTreeNode<T> Right
    {
        get { return (BinaryTreeNode<T>)Children[1]; }
        set { Children[1] = value; }
    }
}

// Classe da Árvore Binária
public class BinaryTree<T>
{
    public BinaryTreeNode<T> Root { get; set; } // Raiz da árvore
    public int Count { get; set; }              // Quantidade de nós (não usado aqui)

    // Travessia em Pré-Ordem (raiz → esquerda → direita)
    private void TraversePreOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            result.Add(node); // Visita o nó atual primeiro
            TraversePreOrder(node.Left, result);  // Depois a esquerda
            TraversePreOrder(node.Right, result); // Depois a direita
        }
    }

    // Travessia Em-Ordem (esquerda → raiz → direita)
    private void TraverseInOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            TraverseInOrder(node.Left, result);   // Primeiro a esquerda
            result.Add(node);                     // Depois o nó atual
            TraverseInOrder(node.Right, result);  // Depois a direita
        }
    }

    // Travessia Pós-Ordem (esquerda → direita → raiz)
    private void TraversePostOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            TraversePostOrder(node.Left, result);   // Primeiro a esquerda
            TraversePostOrder(node.Right, result);  // Depois a direita
            result.Add(node);                       // Por último o nó atual
        }
    }

    // Método público que escolhe o tipo de travessia
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

    // Calcula a altura da árvore (maior altura entre os nós)
    public int GetHeight()
    {
        int height = 0;
        foreach (BinaryTreeNode<T> node in Traverse(TraversalEnum.PREORDER)) // Percorre todos os nós
        {
            height = Math.Max(height, node.GetHeight()); // Guarda o maior valor de altura
        }
        return height;
    }
}

// Programa principal
class Program
{
    static void Main()
    {
        // Criando os nós manualmente
        BinaryTreeNode<int> root = new BinaryTreeNode<int> { Data = 10 };
        BinaryTreeNode<int> node5 = new BinaryTreeNode<int> { Data = 5, Parent = root };
        BinaryTreeNode<int> node20 = new BinaryTreeNode<int> { Data = 20, Parent = root };
        BinaryTreeNode<int> node3 = new BinaryTreeNode<int> { Data = 3, Parent = node5 };
        BinaryTreeNode<int> node7 = new BinaryTreeNode<int> { Data = 7, Parent = node5 };
        BinaryTreeNode<int> node15 = new BinaryTreeNode<int> { Data = 15, Parent = node20 };

        // Conectando os filhos (ligando esquerda/direita)
        root.Left = node5;
        root.Right = node20;
        node5.Left = node3;
        node5.Right = node7;
        node20.Left = node15;

        // Criando a árvore
        BinaryTree<int> tree = new BinaryTree<int> { Root = root };

        // Travessias
        Console.WriteLine("Pré-Ordem:");
        foreach (var n in tree.Traverse(TraversalEnum.PREORDER))
            Console.Write(n.Data + " ");
        Console.WriteLine();

        Console.WriteLine("Em-Ordem:");
        foreach (var n in tree.Traverse(TraversalEnum.INORDER))
            Console.Write(n.Data + " ");
        Console.WriteLine();

        Console.WriteLine("Pós-Ordem:");
        foreach (var n in tree.Traverse(TraversalEnum.POSTORDER))
            Console.Write(n.Data + " ");
        Console.WriteLine();

        // Altura da árvore
        Console.WriteLine("\nAltura da árvore: " + tree.GetHeight());
    }
}