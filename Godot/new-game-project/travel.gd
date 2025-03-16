extends Node2D

func _ready():
	match Global.scene:
		1: $"Scene 1".visible = true
