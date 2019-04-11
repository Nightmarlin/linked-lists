using System;

namespace LinkedLists {

  public class LinkedList {

    private ListItem[] items;


    public ListItem this[int key] {
      get { return getValue(key); }
      set { setValue(key, value); }
    }

    public int size {get;}

    public LinkedList(int size) {
      this.items = new ListItem[size];
      this.size = size;


      for (int? i = 0; i < size; i++) {

        this.items[(int) i] = new ListItem(
          null,
          ((i == 0) ? null : i - 1),
          ((i == size) ? null : i + 1)
        );
      }

    }

    private ListItem getValue(int key) {
      return items[key];
    }

    private void setValue(int key, object value) {
      if (!(value is ListItem item)) {
        throw new NotAListItemException($"Object of type '{value.GetType().FullName}' could not be converted to ListItem");
      }

      items[key] = item;

    }

    private class NotAListItemException : Exception {
      public NotAListItemException(string message) : base(message) { }
    }

  }

}