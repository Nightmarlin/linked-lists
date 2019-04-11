using System;

namespace LinkedLists {

  public class ListItem {

    public int? nextIndex {get; set;}
    public int? prevIndex {get; set;}
    public object value {get; set;}

    public ListItem(object value, int? prevIndex, int? nextIndex) {
      this.value = value;
      this.prevIndex = prevIndex;
      this.nextIndex = nextIndex;
    }

  }

}