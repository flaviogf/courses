# frozen_string_literal: true

class Scene
  def enter
    puts 'This scene is not yet configured. Subclass it and implement enter().'
    exit(0)
  end
end

class Engine
  def initialize(scene_map)
    @scene_map = scene_map
  end

  def play
    current_scene = @scene_map.opening_scene
    last_scene = @scene_map.next_scene('finished')

    while current_scene != last_scene
      next_scene_name = current_scene.enter
      current_scene = @scene_map.next_scene(next_scene_name)
    end

    current_scene.enter
  end
end

class Death < Scene
  @@quips = [
    'You died, You kinda suck at this.',
    'Your mom would be proud... if she were smarter.',
    'Such a luser.',
    'I have a small puppy that\'s better at this.'
  ]

  def enter
    puts @@quips[rand(0..(@@quips.length - 1))]
    exit(0)
  end
end
