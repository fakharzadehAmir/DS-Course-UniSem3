// using System;
// using System.Collections.Generic;
//
// namespace A4
// {
//     public class Order
//     {
//         public Order()
//         {
//             _contact = new List<string>();
//         }
//
//         private List<string> _contact;
//         public void InsertInContact(string newPerson)
//         {
//             if (_contact != null && _contact.Contains(newPerson))
//                 _contact.Remove(newPerson);
//             _contact.Add(newPerson);
//         }
//
//         public void ContactsRecently()
//         {
//             for(var i = _contact.Count - 1; i >= 0 ; i--)
//                 Console.WriteLine(_contact[i]);
//         }
//     }
//
//     public static class Q5
//     {
//         private static void Main(string[] args)
//         {
//             var newOrder = new Order();
//             var inputs = int.Parse(Console.ReadLine());
//             for (var i = 0; i < inputs; i++)
//                 newOrder.InsertInContact(Console.ReadLine());
//             newOrder.ContactsRecently();
//         }
//     }
// }