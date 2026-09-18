package multiplayer.game.utils;

import java.util.HashMap;

import java.util.Map;

public class GameRegistry<K, V> {
    private final HashMap<K, V> storage;

    public GameRegistry() {
        this.storage = new HashMap<>();
    }

    public void put(K key, V value) {
        storage.put(key, value);
    }

    public V get(K key) {
        return storage.get(key);
    }

    public boolean containsKey(K key) {
        return storage.containsKey(key);
    }

    public int size() {
        return storage.size();
    }

    public Map<K, V> snapshot() {
        return new HashMap<>(storage);
    }
}
