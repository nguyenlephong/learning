package com.learning.webmana.poc.controller;

import com.learning.webmana.poc.model.Vocabulary;
import com.learning.webmana.poc.service.VocabularyService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import io.swagger.v3.oas.annotations.Operation;
import io.swagger.v3.oas.annotations.tags.Tag;

import java.util.List;

@RestController
@RequestMapping("/api/vocabulary")
@Tag(name = "Vocabulary API", description = "CRUD operations for vocabulary words")
public class VocabularyController {
    private final VocabularyService vocabularyService;

    public VocabularyController(VocabularyService vocabularyService) {
        this.vocabularyService = vocabularyService;
    }

    @GetMapping
    @Operation(summary = "Get all words", description = "Retrieves a list of vocabulary words")
    public List<Vocabulary> getAllWords() {
        return vocabularyService.getAllWords();
    }

    @PostMapping
    @Operation(summary = "Add a new word", description = "Adds a new vocabulary word")
    public ResponseEntity<Vocabulary> addWord(@RequestBody Vocabulary vocabulary) {
        return ResponseEntity.ok(vocabularyService.addWord(vocabulary));
    }

    @PutMapping("/{word}")
    @Operation(summary = "Update a word", description = "Updates the meaning of an existing vocabulary word")
    public ResponseEntity<Vocabulary> updateWord(@PathVariable String word, @RequestBody Vocabulary updatedVocabulary) {
        Vocabulary updated = vocabularyService.updateWord(word, updatedVocabulary);
        return (updated != null) ? ResponseEntity.ok(updated) : ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{word}")
    @Operation(summary = "Delete a word", description = "Deletes a vocabulary word")
    public ResponseEntity<String> deleteWord(@PathVariable String word) {
        return vocabularyService.deleteWord(word)
                ? ResponseEntity.ok("Deleted successfully")
                : ResponseEntity.notFound().build();
    }
}