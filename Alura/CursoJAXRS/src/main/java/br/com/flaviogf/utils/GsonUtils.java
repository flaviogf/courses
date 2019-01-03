package br.com.flaviogf.utils;

import com.google.gson.Gson;

public class GsonUtils {

    private Gson gson = new Gson();

    public String converteParaJson(Object o) {
        return gson.toJson(o);
    }

    public <T> T converteParaObjeto(String json, Class<T> clazz) {
        return gson.fromJson(json, clazz);
    }
}
