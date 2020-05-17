<?php

namespace HandlingCollections;

class Arrays
{
    public static function remove(array &$array, int $element): void
    {
        $index = array_search($element, $array, true);
        if(!$index) return;
        unset($array[$index]);
    }
}
