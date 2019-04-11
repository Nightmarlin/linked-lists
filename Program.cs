using System;

namespace LinkedLists {
   class Program {
      static void Main(string[] args) {

      int curIdx = 0;
      bool @continue = true;

      Console.Write("How many elements? ==> ");
      var size = (int.TryParse(Console.ReadLine(), out var sz))
                ? sz
                : -1;

      if (size <= 0) {
        Console.WriteLine("No numbers <= 0");
        return;
      }

      LinkedList list = new LinkedList(size);

      while (@continue) {

        //if () {}

        var menu = $"Currently at index: { curIdx } {Environment.NewLine}" +
                   $"Contents are as follows... {Environment.NewLine}" +
                   $"    Value: { ((list[curIdx].value == null) ? "null" : list[curIdx].value.ToString()) }{Environment.NewLine}" +
                   $"    Previous Index: { ((list[curIdx].prevIndex == null) ? "null" : list[curIdx].prevIndex.ToString()) }{Environment.NewLine}" +
                   $"    Next Index: { ((list[curIdx].nextIndex == null) ? "null" : list[curIdx].nextIndex.ToString()) }{Environment.NewLine}" +
                   $"Available actions are: {Environment.NewLine}" +
                   $"  1) Change something{Environment.NewLine}" +
                   $"  2) Navigate{Environment.NewLine}" +
                   $"  0 / Q) Exit{Environment.NewLine}" +
                   "==> ";
        Console.Write(menu);

        var Choice = (int.TryParse(Console.ReadLine(), out var ch))
                      ? (ch > 0)
                        ? ch
                        : 0
                      : 0;

        if (Choice == 1) {

          menu = $"What would you like to change?{Environment.NewLine}" +
                 $"  1) Value{Environment.NewLine}" +
                 $"  2) Previous Index{Environment.NewLine}" +
                 $"  3) Next Index{Environment.NewLine}" +
                 "==> ";
          Console.Write(menu);

          Choice = (int.TryParse(Console.ReadLine(), out var chc))
                    ? (chc > 0)
                      ? chc
                      : 0
                    : 0;

          if (Choice == 1) { list = changeValue(list, curIdx); }
          else if (Choice == 2) { list = changePrevIndex(list, curIdx); }
          else if (Choice == 3) { list = changeNextIndex(list, curIdx); }

        } else if (Choice == 2) {

          menu = $"How would you like to navigate?{Environment.NewLine}" +
                 $"  1) Next Index{Environment.NewLine}" +
                 $"  2) Previous Index{Environment.NewLine}" +
                 $"  3) Pick an Index{Environment.NewLine}" +
                 "==> ";
          Console.Write(menu);

          Choice = int.TryParse(Console.ReadLine(), out var chc) ? chc : -1;


          if (Choice == 1) {
            if (list[curIdx].nextIndex == null) {
              Console.WriteLine("No Next Index has been set, we are at the end of the list");
            } else {
              curIdx = (int) list[curIdx].nextIndex;
            }

          } else if (Choice == 2) {
            if (list[curIdx].prevIndex == null) {
              Console.WriteLine("No Previous Index has been set, we are at the end of the list");
            } else {
              curIdx = (int) list[curIdx].prevIndex;
            }

          } else if (Choice == 3) {
            curIdx = getNewLocation(list, curIdx);
          }

        } else {
          @continue = false;
        }
      }

    }

    private static LinkedList changeValue(LinkedList list, int index) {
      Console.Write("What is the new value? ==> ");
      list[index].value = Console.ReadLine();

      return list;
    }

    private static LinkedList changePrevIndex(LinkedList list, int index) {
      Console.Write("What is the new previous index? (type any non-number to remove the reference) ==> ");

      list[index].prevIndex = getOutput(list, index, Console.ReadLine());

      return list;
    }

    private static LinkedList changeNextIndex(LinkedList list, int index) {
      Console.Write("What is the new next index? (type any non-number to remove the reference) ==> ");

      list[index].nextIndex = getOutput(list, index, Console.ReadLine());

      return list;
    }

    private static int? getOutput(LinkedList list, int index, string input) {

      if (input == "null") {
        list[index].nextIndex = null;
        return null;
      }

      if (!int.TryParse(input, out var asInt)) {
        return null;
      }
      if (!validateBounds(list, asInt)) {
        return null;
      }

      return asInt;

    }

    private static int getNewLocation(LinkedList list, int curIdx) {

      Console.Write("Where shall we go? ==> ");

      var newIndex = curIdx;

      if (int.TryParse(Console.ReadLine(), out var ni)) {
        if (validateBounds(list, ni)) {
          Console.WriteLine(ni);
          newIndex = ni;
        }
      }

      return newIndex;
    }

    private static bool validateBounds(LinkedList list, int index) => (index >= 0 && index < list.size);
  }
}
