using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using Wintellect.PowerCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerCollections.Tests
{
	[TestClass]
	public class StackTests
	{
		[TestMethod]
		public void PushMethodShouldAddElementToTheTopOfTheStack()
		{
			Stack<int> stack = new Stack<int>(15);

			stack.Push(5);
			stack.Push(6);

			Assert.AreEqual(stack.count, 2);
		}

		[TestMethod]
		public void PopMethodShouldTakeElementFromTheTopOfTheStackAndReturnIt()
		{
			Stack<int> stack = new Stack<int>(15);

			stack.Push(5);
			stack.Push(6);
			int element = stack.Pop();

			Assert.AreEqual(element, 6);
		}

		[TestMethod]
		public void TopMethodShouldReturnValueOfTheElementAtTheTopOfTheStack()
		{
			Stack<int> stack = new Stack<int>(15);

			stack.Push(5);
			stack.Push(6);
			int element = stack.Top();

			Assert.AreEqual(element, 6);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException), "array outside")]
		public void PushMethodOutsideTheArray()
		{
			Stack<int> stack = new Stack<int>(1);

			stack.Push(10);
			stack.Push(15);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException), "array empty")]
		public void TopMethodOutsideTheArray()
		{
			Stack<int> stack = new Stack<int>(1);

			stack.Top();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException), "array empty")]
		public void PopMethodOutsideTheArray()
		{
			Stack<int> stack = new Stack<int>(1);

			stack.Pop();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException), "array outside")]
		public void PushOverflowsStack()
		{
			Stack<int> stack = new Stack<int>(1);

			stack.Push(5);
			stack.Push(6);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException), "array length is negative")]
		public void AssignNegativeNumberToTheCapacity()
        {
			Stack<int> stack = new Stack<int>(-2);
        }

		[TestMethod]
		public void WhenStackIsCreatedItIsEmpty()
		{
			Stack<int> stack = new Stack<int>(2);

			Assert.AreEqual(stack.count, 0);
		}

		[TestMethod]
		public void StackCountAreEqualStackCapacity()
		{
			Stack<int> stack = new Stack<int>(1);

			stack.Push(5);

			Assert.AreEqual(stack.count, stack.capacity);
		}

		[TestMethod]
		public void PopIsNotFullWhenStakIsFull()
		{
			Stack<int> stack = new Stack<int>(2);

			stack.Push(5);
			stack.Push(10);
			stack.Pop();

			Assert.AreNotEqual(stack.count, stack.capacity);
		}

		[TestMethod]
		public void GetEnumeratorShouldOutputArrayFromTopToBottom()
		{
			Stack<int> stack = new Stack<int>(5);

			int[] numbers = new int[] { 1, 2, 3, 4, 5 };

			foreach (int number in numbers)
			{
				stack.Push(number);
			}

			var check = from i in stack select i;

			CollectionAssert.AreEqual(check.ToArray(), numbers.Reverse().ToArray());
		}
	}
}
