package br.com.flaviogf.manager.extensions;

public class StringExtensions {
    public static String toTitleCase(String text) {
        if (text == null || text.isEmpty()) {
            return text;
        }

        final StringBuilder converted = new StringBuilder();

        boolean convertNext = true;

        for (char ch : text.toCharArray()) {
            if (Character.isSpaceChar(ch)) {
                convertNext = true;
            } else if (convertNext) {
                ch = Character.toTitleCase(ch);
                convertNext = false;
            } else {
                ch = Character.toLowerCase(ch);
            }
            converted.append(ch);
        }

        return converted.toString();
    }
}