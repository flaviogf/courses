<?php

require_once 'vendor/autoload.php';

use GuzzleHttp\Client;
use Symfony\Component\DomCrawler\Crawler;

use Flaviogf\CourseFinder\Finder;

$client = new Client(['base_uri' => 'http://www.alura.com.br/']);

$finder = new Finder($client);

$courses = $finder->find('cursos-online-programacao/php');

foreach($courses as $course) {
    echo $course . PHP_EOL;
}
