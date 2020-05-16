<?php

namespace Bank\Models;

class Document
{
    private string $value;

    public function __construct(string $value)
    {
        $this->value = $value;
    }

    public function getValue() 
    {
        return $this->value;
    }
}