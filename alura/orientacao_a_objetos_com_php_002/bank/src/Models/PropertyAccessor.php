<?php

namespace Bank\Models;

trait PropertyAccessor
{
    public function __get(string $attribute)
    {
        $method = "get" . ucfirst($attribute);
        return $this->$method();
    }
}