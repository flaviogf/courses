<?php

namespace Flaviogf\CourseFinder;

use GuzzleHttp\Client;
use Symfony\Component\DomCrawler\Crawler;

class Finder
{
    private Client $client;

    public function __construct(Client $client)
    {
        $this->client = $client;
    }

    public function find(string $url): array
    {
        $response = $this->client->request('GET', $url);

        $html = (string) $response->getBody();

        $crawler = new Crawler($html);

        return $crawler->filter('.card-curso__nome')->each(function (Crawler $node) {
            return $node->text();
        });
    }
}
