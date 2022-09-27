#!/usr/bin/env python
# -*- coding: utf-8 -*-

#Modules
import sys
import pygame
from pygame.locals import *
#Constants
WIDTH = 640
HEIGHT = 480
#Class
class Bola(pygame.sprite.Sprite):
    def __init__(self):
        pygame.sprite.Sprite.__init__(self)
        self.image = load_image("/media/pi/847C-1A0C/Web/Gifs/ball.png")
        self.rect = self.image.get_rect()
        self.rect.centerx = WIDTH / 2
        self.rect.centery = HEIGHT / 2
        self.speed = [0-5, -0.5]
#Functions
def load_image(filename, transparent=False):
    try: image = pygame.image.load(filename)
    except pygame.error:
        raise SystemExit
    image = image.convert()
    if transparent:
        color = image.get_at((0,0))
        image.set_colorkey(color, RLACCEL)
    return image

#Main
def main():
#iniciamos ventana
    screen = pygame.display.set_mode((WIDTH, HEIGHT))
    pygame.display.set_caption("Pruebas Pygame")
    background_image = load_image("/media/pi/847C-1A0C/Web/imgs/fondo-madera-vintage.png")
    bola = Bola()
#con un bucle infinito ponemos al detector de eventos en escucha
#si el evento es cerrar ventana (la cruz de la ventana) entonces envia
#una señal de cerrar a la ventana
    while True:
        for eventos in pygame.event.get():
            if eventos.type == QUIT:
                sys.exit(0)
        screen.blit(background_image, (0,0))
        screen.blit(bola.image, bola.rect)
        pygame.display.flip()
    return 0
#Without this game wont run
if __name__ == "__main__":
    pygame.init()
    main()

