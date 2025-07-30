void spreadOperator() {
  var arr = [-1, -2, -3];
  var arrSpread = [...arr, 1, 2, 3];
  print('spread operator $arrSpread');
}

void dataStruct(){
  var list = <int>[1 ,2 ,3];
  list.add(4);
  print('list length: ${list.length} - ${list[3]}');
}

void main() {
  spreadOperator();
  dataStruct();
}