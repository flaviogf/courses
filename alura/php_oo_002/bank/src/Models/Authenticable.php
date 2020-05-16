<?php

namespace Bank\Models;

interface Authenticable
{
    function attempt(string $password): bool;
}