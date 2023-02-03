// javascript program to insert element in binary tree

/*
 * A binary tree node has key, pointer to left child and a pointer to right
 * child
 */
class Node {
  constructor(val) {
    this.key = val;
    this.left = null;
    this.right = null;
  }
}

var temp;

/* Inorder traversal of a binary tree */
function inorder(temp) {
  if (temp == null) {
    return;
  }

  inorder(temp.left);
  console.log(temp.key + " ");
  inorder(temp.right);
}

/* function to insert element in binary tree */
function insert(temp, key) {
  if (temp == null) {
    root = new Node(key);
    return;
  }
  var q = [];
  q.push(temp);

  // Do level order traversal until we find
  // an empty place.
  while (q.length != 0) {
    temp = q.shift();

    if (temp.left == null) {
      temp.left = new Node(key);
      break;
    } else q.push(temp.left);

    if (temp.right == null) {
      temp.right = new Node(key);
      break;
    } else q.push(temp.right);
  }
}

function deleteDeepest(root, delNode) {
  let q = [];
  q.push(root);

  let temp = null;

  // Do level order traversal until last node
  while (q.length > 0) {
    temp = q[0];
    q.shift();

    if (temp == delNode) {
      temp = null;
      return;
    }
    if (temp.right != null) {
      if (temp.right == delNode) {
        temp.right = null;
        return;
      } else q.push(temp.right);
    }

    if (temp.left != null) {
      if (temp.left == delNode) {
        temp.left = null;
        return;
      } else q.push(temp.left);
    }
  }
}

// Function to delete given element
// in binary tree
function Delete(root, key) {
  if (root == null) return;

  if (root.left == null && root.right == null) {
    if (root.key == key) {
      root = null;
      return;
    } else return;
  }

  let q = [];
  q.push(root);
  let temp = null,
    keyNode = null;

  // Do level order traversal until
  // we find key and last node.
  while (q.length > 0) {
    temp = q[0];
    q.shift();

    if (temp.key == key) keyNode = temp;

    if (temp.left != null) q.push(temp.left);

    if (temp.right != null) q.push(temp.right);
  }

  if (keyNode != null) {
    let x = temp.key;
    deleteDeepest(root, temp);
    keyNode.key = x;
  }
}

function findFullNode(root)
{
    if (root != null)
        {
            findFullNode(root.left);
            if (root.left != null && root.right != null)
                console.log(root.data + " ");
            findFullNode(root.right);
        }
}

var root = new Node(prompt("enter any number for root"));
insert(root, key);
console.log(root)
inorder(root)
// root.left = new Node(prompt("enter any number for left node"));
// root.left.left = new Node(prompt("enter any number for left left node"));
// root.right = new Node(prompt("enter any number for right node"));
// root.right.left = new Node(prompt("enter any number for left of right node"));
// root.right.right = new Node(prompt("enter any number for right of right node"));
// Driver code
// var option = prompt("enter option");
// // do{
//   switch (option) {
//   case 1:
//     var key = prompt("enter any new value");
//     insert(root, key);
//     console.log(root)
//     inorder(root)
//     break;
//   case 2:
//     var key = prompt("enter value you want delete");
//     Delete(root,key);
//     break;
//   case 3:
//     findFullNode(root);
//     break;
// }
// } while(option != null)


// console.log("Inorder traversal before insertion:");
// inorder(root);

// console.log("<br\>Inorder traversal after insertion:");
// inorder(root);
