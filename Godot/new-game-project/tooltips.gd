extends RichTextLabel

func _make_custom_tooltip(for_text: String) -> Object:
	var toolTipLabel = null
	if (for_text != ""):
		toolTipLabel = RichTextLabel.new()
		# toolTipLabel.bbcode_enabled
		toolTipLabel.text = for_text
		toolTipLabel.add_theme_font_override("normal_font", load("res://fonts/OpenSans-VariableFont_wdth,wght.ttf"))
		toolTipLabel.add_theme_color_override("default_color", Color("#000000"))
		var usedFont: Font = toolTipLabel.get_theme_default_font()
		var cmin: Vector2 = usedFont.get_string_size(for_text)
		toolTipLabel.custom_minimum_size = cmin
		var style_box: StyleBoxFlat = StyleBoxFlat.new()
		style_box.set_bg_color(Color("#9999af"))
		style_box.set_border_color(Color("#9999af"))
		style_box.set_border_width_all(5)
		style_box.set_corner_radius_all(3)
		theme = Theme.new()
		theme.set_stylebox("panel", "TooltipPanel", style_box)
	
	return toolTipLabel
