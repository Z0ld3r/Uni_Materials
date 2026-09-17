public class Queue<T> {
    private final T[] elements;
    private int size;

    public Queue(T[] elements){
        this.elements = elements;
        this.size = 0;
    }

    public boolean isEmpty(){
        return size == 0;
    }

    public boolean isFull(){
        return size == elements.length;
    }

    public void insert(T element){
        if (!isFull()){
            elements[size] = element;
            size++;
        }
    }

    public T pop(){
        if (!isEmpty()){
            return elements[0];
        }
        return null;
    }

    public T delete(){
        if (!isEmpty()){
            T element = elements[0];
            for (int i = 0; i < size-1; i++) {
                elements[i] = elements[i+1];
            }
            elements[size-1] = null;
            size--;
            return element;
        }

        return null;
    }
}
