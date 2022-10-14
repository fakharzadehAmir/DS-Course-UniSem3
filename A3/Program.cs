// using System;
//
// namespace A3
// {
//     public class Node
//     {
//         public int Key { get; set; }
//         public Node Left, Right;
//     }
//
//     internal class BinarySearchTree
//     {
//         public int Insert(int num)
//         {
//             if (this._root == null) this._root = new Node() {Key = num};
//             else
//             {
//                 var insertNode = this._root;
//                 var prevNode = new Node();
//                 while (insertNode != null)
//                 {
//                     prevNode = insertNode;
//                     insertNode = insertNode.Key > num ? insertNode.Left : insertNode.Right;
//                 }
//
//                 if (num < prevNode.Key)
//                     prevNode.Left = new Node {Key = num};
//                 else
//                     prevNode.Right = new Node() {Key = num};
//             }
//
//             return num;
//         }
//
//         public int GetMax()
//         {
//             var nextRight = _root;
//             while (nextRight.Right != null)
//                 nextRight = nextRight.Right;
//             return nextRight.Key;
//         }
//
//         public int GetMin()
//         {
//             var nextLeft = _root;
//             while (nextLeft.Left != null)
//                 nextLeft = nextLeft.Left;
//             return nextLeft.Key;
//         }
//
//         public bool Search(int num)
//         {
//             var parentNode = _root;
//             while (parentNode != null)
//             {
//                 if (parentNode.Key == num) return true;
//                 parentNode = parentNode.Key < num ? parentNode.Right : parentNode.Left;
//             }
//
//             return false;
//         }
//
//         public void PreOrder()
//         {
//             this.PreOrderWithNode(this._root);
//             Console.WriteLine();
//         }
//
//         private void PreOrderWithNode(Node parentNode)
//         {
//             if (parentNode == null) return;
//             Console.Write(parentNode.Key + " ");
//             this.PreOrderWithNode(parentNode.Left);
//             this.PreOrderWithNode(parentNode.Right);
//         }
//
//         public void InOrder()
//         {
//             this.InOrderWithNode(this._root);
//             Console.WriteLine();
//         }
//
//         private void InOrderWithNode(Node parentNode)
//         {
//             if (parentNode == null) return;
//             this.InOrderWithNode(parentNode.Left);
//             Console.Write(parentNode.Key + " ");
//             this.InOrderWithNode(parentNode.Right);
//         }
//
//         public void PostOrder()
//         {
//             this.PostOrderWithNode(this._root);
//             Console.WriteLine();
//         }
//
//         private void PostOrderWithNode(Node parentNode)
//         {
//             if (parentNode == null) return;
//             this.PostOrderWithNode(parentNode.Left);
//             this.PostOrderWithNode(parentNode.Right);
//             Console.Write(parentNode.Key + " ");
//         }
//
//         public bool Delete(int num)
//         {
//             var result = this.Search(num);
//             this._root = this.DeleteWithNode(this._root, num); 
//             return result;
//         }
//
//     private Node DeleteWithNode(Node currentNode ,int num)
//         {
//             if (currentNode == null) return null;
//             if (currentNode.Key < num) currentNode.Right = this.DeleteWithNode(currentNode.Right, num);
//             else if (currentNode.Key > num) currentNode.Left = this.DeleteWithNode(currentNode.Left, num);
//             else
//             {
//                 if (currentNode.Right == null) return currentNode.Left;
//                 else if (currentNode.Left == null) return currentNode.Right;
//                 currentNode.Key = Predecessor(currentNode.Left).Key;
//                 currentNode.Left = this.DeleteWithNode(currentNode.Left, currentNode.Key);
//             }
//             return currentNode;
//         }
//         private static Node Predecessor(Node currentNode)
//         {
//             while (currentNode.Right != null)
//                 currentNode = currentNode.Right;
//             return currentNode;
//         }
//         private Node _root;
//     }
//     internal static class Program
//     {
//         private static void Main()
//         {
//             var bst = new BinarySearchTree();
//             var sizeOfBst = int.Parse(Console.ReadLine());
//             var numbers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
//             for(var i = 0 ; i < sizeOfBst ; i++)
//                 bst.Insert(numbers[i]);
//             var lineNum = 0;
//             var orders = int.Parse(Console.ReadLine());
//             string line;
//             while (lineNum != orders)
//             {
//                 line = Console.ReadLine();
//                 switch (line.Split()[0])
//                 {
//                     case "insert":
//                         Console.WriteLine(bst.Insert(int.Parse(line.Split()[1])));
//                         break;
//                     case "delete":
//                         Console.WriteLine(bst.Delete(int.Parse(line.Split()[1])));
//                         break;
//                     case "getmax":
//                         Console.WriteLine(bst.GetMax());
//                         break;
//                     case "getmin":
//                         Console.WriteLine(bst.GetMin());
//                         break;
//                     case "search":
//                         Console.WriteLine(bst.Search(int.Parse(line.Split()[1])));
//                         break;
//                     case "inorder":bst.InOrder();
//                         break;
//                     case "preorder":bst.PreOrder();
//                         break;
//                     case "postorder":bst.PostOrder();
//                         break;
//                 }
//                 lineNum++;
//             }
//         }
//     }
// }